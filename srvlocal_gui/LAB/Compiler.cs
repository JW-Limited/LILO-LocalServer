using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui.LAB
{
    public class Compiler
    {
        private static CompilerParameters _parameters;
        private static readonly CSharpCodeProvider _provider = new CSharpCodeProvider();

        public static Assembly CompileFromFile(string filepath, string appname)
        {
            SetupParameters(appname);
            return ApplyCompileCode(ReadCodeFromFile(filepath), appname);
        }

        public static Assembly CompileCode(string code, string appname)
        {
            SetupParameters(appname);
            return ApplyCompileCode(code, appname);
        }

        public static List<string> GetReferencedAssemblies()
        {
            List<string> assemblies = new List<string>();
            foreach (string assembly in _parameters.ReferencedAssemblies)
            {
                assemblies.Add(assembly);
            }
            return assemblies;
        }

        public static void AddReferencedAssembly(string assembly)
        {
            _parameters.ReferencedAssemblies.Add(assembly);
        }

        public static void RemoveReferencedAssembly(string assembly)
        {
            _parameters.ReferencedAssemblies.Remove(assembly);
        }

        public static void ClearReferencedAssemblies()
        {
            _parameters.ReferencedAssemblies.Clear();
        }

        public static List<string> GetCompileErrors(CompilerResults results)
        {
            var errors = new List<string>();
            foreach (CompilerError error in results.Errors)
            {
                errors.Add(error.ErrorText);
            }
            return errors;
        }
        public static List<string> GetCompileWarnings(CompilerResults results)
        {
            var warnings = new List<string>();
            foreach (CompilerError warning in results.Errors)
            {
                if (warning.IsWarning)
                {
                    warnings.Add(warning.ErrorText);
                }
            }
            return warnings;
        }

        public static Version GetCompilerVersion()
        {
            return _provider.GetType().Assembly.GetName().Version;
        }


        private static void SetupParameters(string appname)
        {
            _parameters = new CompilerParameters();
            _parameters.GenerateExecutable = true;
            _parameters.GenerateInMemory = true;
            _parameters.OutputAssembly = appname + ".exe";
            _parameters.ReferencedAssemblies.Add("System.dll");
        }

        private static string ReadCodeFromFile(string filePath)
        {
            string code;
            using (StreamReader sr = new StreamReader(filePath))
            {
                code = sr.ReadToEnd();
            }
            return code;
        }
        public static Assembly CompileFromFiles(string[] filePaths, string appname)
        {
            SetupParameters(appname);

            string[] codeFiles = new string[filePaths.Length];

            for (int i = 0; i < filePaths.Length; i++)
            {
                codeFiles[i] = ReadCodeFromFile(filePaths[i]);
            }

            return ApplyCompileCode(string.Join(Environment.NewLine, codeFiles), appname);
        }


        public static Assembly CompileFromDirectory(string directoryPath, string appname, string searchPattern)
        {
            string[] filePaths = Directory.GetFiles(directoryPath, searchPattern);

            return CompileFromFiles(filePaths, appname);
        }
    

        private static Assembly ApplyCompileCode(string code, string appname)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults results = provider.CompileAssemblyFromSource(_parameters, code);
            if (results.Errors.HasErrors)
            {
                throw new Exception("Error compiling code: " + results.Errors[0].ErrorText);
            }
            return results.CompiledAssembly;
        }

        public static Assembly CompileFromFilesWithReferences(string[] filePaths, string appname, string[] references)
        {
            SetupParameters(appname);

            string[] codeFiles = new string[filePaths.Length];

            for (int i = 0; i < filePaths.Length; i++)
            {
                codeFiles[i] = ReadCodeFromFile(filePaths[i]);
            }

            foreach (string reference in references)
            {
                _parameters.ReferencedAssemblies.Add(reference);
            }

            return ApplyCompileCode(string.Join(Environment.NewLine, codeFiles), appname);
        }

    }
}
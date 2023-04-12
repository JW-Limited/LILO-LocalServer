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
    /// 🔨 Compiles C# code into an assembly
    public class Compiler
    {
        private static CompilerParameters _parameters;
        
        /// <summary>
        /// Setup the compiler parameters, compile a file and generate an executable
        /// </summary>
        /// <param name="filepath">Path to the file</param>
        /// <param name="appname">Name of application without extension</param>
        /// <returns></returns>

        public static Assembly CompileFromFile(string filepath, string appname)

        {
            setupParameters(appname); // Set the compiler parameters
            return applyCompileCode(ReadCodeFromFile(filepath), appname); // Compile the code
        }
        
        /// <summary>
        /// Setup the compiler parameters, Compile c# code and generate an exe
        /// </summary>
        /// <param name="code">C# source code</param>
        /// <param name="appname">Name of application without extension</param>
        /// <returns></returns>
        public static Assembly CompileCode(string code, string appname)
        {
            setupParameters(appname); // Set the compiler parameters
            return applyCompileCode(code, appname); // Compile the code
        }

        /// <summary>
        /// Setup the compiler parameters
        /// </summary>
        /// <param name="appname">Name of application without extension</param>

        private static void setupParameters(string appname){
            // 📝 Set compiler parameters

            _parameters = new CompilerParameters();
            _parameters.GenerateExecutable = true; 
            _parameters.GenerateInMemory = true;
            _parameters.OutputAssembly = appname + ".exe";
            _parameters.ReferencedAssemblies.Add("System.dll");
        }
        
        /// <summary>
        /// Read the code from the given file path
        /// </summary>

        /// <param name="filePath">Path to the file</param>
        /// <returns></returns>
        private static string ReadCodeFromFile(string filePath)
        {           
            string code;
            using (StreamReader sr = new StreamReader(filePath))
            {
                code = sr.ReadToEnd();
            }
            return code;
        }
        
        /// <summary>
        /// Compile the given code using the set parameters
        /// </summary>
        /// <param name="code">C# source code</param>
        /// <param name="appname">Name of application without extension</param>
        /// <returns></returns>
        private static Assembly applyCompileCode(string code, string appname)
        {
            CompilerResults results = Compile(code);
            if (results.Errors.HasErrors)
            {
                throw new Exception("Error compiling code: " + results.Errors[0].ErrorText);
            }
            return results.CompiledAssembly;
        }
        
        /// <summary>
        /// Compile the given code using the set parameters
        /// </summary>
        /// <param name="code">C# source code</param>
        /// <returns></returns>
        private static CompilerResults Compile(string code)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();    
            return provider.CompileAssemblyFromSource(_parameters, code);
        }
     
        /// <summary>
        /// Get the list of errors during compilation 
        /// </summary>
        /// <param name="results">compilation results</param>
        /// <returns>List of errors</returns>
        public static List<string> GetCompileErrors(CompilerResults results)
        {
            var errors = new List<string>();
            foreach(CompilerError error in results.Errors) 
            {
                errors.Add(error.ErrorText);
            }  
            return errors;
        }
    }
}
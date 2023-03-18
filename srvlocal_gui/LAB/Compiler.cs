using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui.LAB
{
    /// 🔨 Compiles C# code into an assembly
    public class Compiler
    {
        public static Assembly CompileCode(string code,string appname)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();

            // 📝 Set compiler parameters
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true; 
            parameters.GenerateInMemory = true;
            parameters.OutputAssembly = appname + ".exe";
            parameters.ReferencedAssemblies.Add("System.dll");

            // 🔨 Compile the code
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                throw new Exception("Error compiling code: " + results.Errors[0].ErrorText);
            }
            // 📦 Return the compiled assembly
            return results.CompiledAssembly;
        }
    }
}
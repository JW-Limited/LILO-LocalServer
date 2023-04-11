/*
        Copyright© 2023 Joe Valentino Lengefeld

        Licensed under the Apache License, Version 2.0 (the "License");
        you may not use this file except in compliance with the License.
        You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
        Unless required by applicable law or agreed to in writing, software
        distributed under the License is distributed on an "AS IS" BASIS,
        WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
        See the License for the specific language governing permissions and
        limitations under the License.

        Last edit : 02.04.2023
*/

using System;
using System.Text.RegularExpressions;
using System.IO;
using Console = System.Console;
using System.Globalization;

namespace LABLibary.Assistant
{
    public class Code
    {
        private string generatedCode;
        public static void _Generate()
        {
            var program = new Code();
            program.generate(); // Prompt the user for input and generate code

            // Write the generated code to a file
            var code = "/* Generated code */\n" + program.generatedCode;
            File.WriteAllText("output.cs", code);
        }


        public void generate()
        {
            var commands = LoadCommandsFromConfigFile("commands.config");

            // Prompt the user for the code construct they want to generate and the name they want to give it
            System.Console.WriteLine("Enter \"help\" command to get all the code constructs.\n");
            System.Console.Write("Enter the code construct you want to generate (e.g., \"property\", \"method\", \"interface\"): ");
            
            var constructName = System.Console.ReadLine().ToLower();
            if(constructName.Contains("help")){
                var allHelp = File.ReadAllText("commands.config");
                System.Console.WriteLine("Help: \n\n" + allHelp);
            }
            else{
                System.Console.Write($"Enter the name of the {constructName}: ");
            var constructNameLowerCase = System.Console.ReadLine().ToLower();
            var constructNameTitleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(constructNameLowerCase);

            // Generate the template for the code construct based on user input
            switch (constructName)
            {
                case "property":
                    AddPropertyTemplate(constructNameLowerCase, commands);
                    break;
                case "method":
                    AddMethodTemplate(constructNameTitleCase, commands);
                    break;
                case "constructor":
                    AddConstructorTemplate(constructNameTitleCase, commands);
                    break;
                case "static method":
                    AddStaticMethodTemplate(constructNameTitleCase, commands);
                    break;
                case "interface":
                    AddInterfaceTemplate(constructNameTitleCase, commands);
                    break;
                case "delegate":
                    AddDelegateTemplate(constructNameTitleCase, commands);
                    break;
                case "event":
                    AddEventTemplate(constructNameTitleCase, commands);
                    break;
                case "generic class":
                    AddGenericClassTemplate(constructNameTitleCase, commands);
                    break;
                case "notify property":
                    AddNotifyPropertyTemplate(constructNameTitleCase, commands);
                    break;
                default:
                    System.Console.WriteLine($"Unsupported code construct: {constructName}");
                    return;
            }

             UpdateCommandsConfigFile(commands);

            // Parse the user's input to determine the appropriate command
            var userInput = $"create a {constructNameLowerCase} {constructNameTitleCase}";
            var foundCommand = commands.FirstOrDefault(cmd => userInput.Contains(cmd.Key));

            // If a matching command was found, generate the corresponding code
            if (foundCommand.ToString() != null)
            {
                // Extract any variables from the command description and prompt the user to fill them in
                var variables = new List<string>();
                var codeTemplate = foundCommand.Value;
                foreach (Match match in Regex.Matches(codeTemplate, "%[^%]*%"))
                {
                    variables.Add(match.Value);
                    System.Console.Write($"Enter value for {match.Value}: ");
                    var value = System.Console.ReadLine();
                    codeTemplate = codeTemplate.Replace(match.Value, value);
                }    // Generate the final C# code with namespace and import statements
                generatedCode = $"{codeTemplate}\n";
                

                // Prompt the user to provide a namespace for the generated code
                System.Console.Write("Enter a namespace for the generated code: ");
                var namespaceName = System.Console.ReadLine();

                // Add the namespace around the generated code
                generatedCode = $"using System;\nusing System.ComponentModel;\n\nnamespace {namespaceName}\n{{\n{generatedCode}}}";
                System.Console.WriteLine($"Generated code:\n{generatedCode}");

                System.Console.WriteLine($"Code for {constructNameTitleCase} {constructNameLowerCase} created.");
                System.Console.WriteLine();

            }
            else
            {
                System.Console.WriteLine($"Command 'create a {constructNameLowerCase} {constructNameTitleCase}' not recognized.");
            }
            }

        }

                // Add a template for generating a C# property
        private const string PROPERTY_TEMPLATE = "public %PROPERTY_TYPE% %PROPERTY_NAME% {{ get; set; }}";
        private const string PROPERTY_TYPE_VAR = "%PROPERTY_TYPE%";
        private const string PROPERTY_NAME_VAR = "%PROPERTY_NAME%";
        private void AddPropertyTemplate(string propertyName, Dictionary<string, string> commands)
        {
        commands[$"create a {propertyName} property"] = PROPERTY_TEMPLATE.Replace(PROPERTY_TYPE_VAR, "%PROPERTY_TYPE%")
        .Replace(PROPERTY_NAME_VAR, propertyName);
        }

        // Add a template for generating a C# method
        private const string METHOD_TEMPLATE = "public %RETURN_TYPE% %METHOD_NAME%(%PARAMETERS%) { %BODY% }";
        private const string METHOD_RETURN_TYPE_VAR = "%RETURN_TYPE%";
        private const string METHOD_NAME_VAR = "%METHOD_NAME%";
        private const string METHOD_PARAMETERS_VAR = "%PARAMETERS%";
        private const string METHOD_BODY_VAR = "%BODY%";
        private void AddMethodTemplate(string methodName, Dictionary<string, string> commands)
        {
        commands[$"create a {methodName} method"] = METHOD_TEMPLATE.Replace(METHOD_RETURN_TYPE_VAR, "%RETURN_TYPE%")
        .Replace(METHOD_NAME_VAR, methodName)
        .Replace(METHOD_PARAMETERS_VAR, "%PARAMETERS%")
        .Replace(METHOD_BODY_VAR, "%BODY%");
        }

        // Add a template for generating a C# constructor
        private const string CONSTRUCTOR_TEMPLATE = "public %CLASS_NAME%(%PARAMETERS%) { %BODY% }";
        private const string CONSTRUCTOR_CLASS_NAME_VAR = "%CLASS_NAME%";
        private const string CONSTRUCTOR_PARAMETERS_VAR = "%PARAMETERS%";
        private const string CONSTRUCTOR_BODY_VAR = "%BODY%";
        private void AddConstructorTemplate(string className, Dictionary<string, string> commands)
        {
        commands[$"create a {className} constructor"] = CONSTRUCTOR_TEMPLATE.Replace(CONSTRUCTOR_CLASS_NAME_VAR, className)
        .Replace(CONSTRUCTOR_PARAMETERS_VAR, "%PARAMETERS%")
        .Replace(CONSTRUCTOR_BODY_VAR, "%BODY%");
        }
        // Add a template for generating a static C# method
        private const string STATIC_METHOD_TEMPLATE = "public static %RETURN_TYPE% %METHOD_NAME%(%PARAMETERS%) { %BODY% }";
        private const string STATIC_METHOD_RETURN_TYPE_VAR = "%RETURN_TYPE%";
        private const string STATIC_METHOD_NAME_VAR = "%METHOD_NAME%";
        private const string STATIC_METHOD_PARAMETERS_VAR = "%PARAMETERS%";
        private const string STATIC_METHOD_BODY_VAR = "%BODY%";
        private void AddStaticMethodTemplate(string methodName, Dictionary<string, string> commands)
        {
        commands[$"create a static {methodName} method"] = STATIC_METHOD_TEMPLATE.Replace(STATIC_METHOD_RETURN_TYPE_VAR, "%RETURN_TYPE%")
        .Replace(STATIC_METHOD_NAME_VAR, methodName)
        .Replace(STATIC_METHOD_PARAMETERS_VAR, "%PARAMETERS%")
        .Replace(STATIC_METHOD_BODY_VAR, "%BODY%");
        }
                                                                 
                // Add a template for generating a C# interface
        private const string INTERFACE_TEMPLATE = "public interface %INTERFACE_NAME% { %BODY% }";
        private const string INTERFACE_NAME_VAR = "%INTERFACE_NAME%";
        private const string INTERFACE_BODY_VAR = "%BODY%";
        private void AddInterfaceTemplate(string interfaceName, Dictionary<string, string> commands)
        {
        commands[$"create an {interfaceName} interface"] = INTERFACE_TEMPLATE.Replace(INTERFACE_NAME_VAR, interfaceName)
        .Replace(INTERFACE_BODY_VAR, "%BODY%");
        }

        // Add a template for generating a C# delegate
        private const string DELEGATE_TEMPLATE = "public delegate %RETURN_TYPE% %DELEGATE_NAME%(%PARAMETERS%);";
        private const string DELEGATE_RETURN_TYPE_VAR = "%RETURN_TYPE%";
        private const string DELEGATE_NAME_VAR = "%DELEGATE_NAME%";
        private const string DELEGATE_PARAMETERS_VAR = "%PARAMETERS%";
        private void AddDelegateTemplate(string delegateName, Dictionary<string, string> commands)
        {
        commands[$"create a {delegateName} delegate"] = DELEGATE_TEMPLATE.Replace(DELEGATE_RETURN_TYPE_VAR, "%RETURN_TYPE%")
        .Replace(DELEGATE_NAME_VAR, delegateName)
        .Replace(DELEGATE_PARAMETERS_VAR, "%PARAMETERS%");
        }
        private const string EVENT_TEMPLATE = "public event %DELEGATE_NAME% %EVENT_NAME%;";
        private const string EVENT_DELEGATE_NAME_VAR = "%DELEGATE_NAME%";
        private const string EVENT_NAME_VAR = "%EVENT_NAME%";
        private void AddEventTemplate(string eventName, Dictionary<string, string> commands)
        {
        commands[$"create an {eventName} event"] = EVENT_TEMPLATE.Replace(EVENT_DELEGATE_NAME_VAR, "%DELEGATE_NAME%")
        .Replace(EVENT_NAME_VAR, eventName);
        }

        // Add a template for generating a C# generic class
        private const string GENERIC_CLASS_TEMPLATE = "public class %CLASS_NAME%<%TYPE_PARAMETERS%> { %BODY% }";
        private const string GENERIC_CLASS_NAME_VAR = "%CLASS_NAME%";
        private const string GENERIC_TYPE_PARAMETERS_VAR = "%TYPE_PARAMETERS%";
        private const string GENERIC_CLASS_BODY_VAR = "%BODY%";
        private void AddGenericClassTemplate(string className, Dictionary<string, string> commands)
        {
        commands[$"create a {className} generic class"] = GENERIC_CLASS_TEMPLATE.Replace(GENERIC_CLASS_NAME_VAR, className)
        .Replace(GENERIC_TYPE_PARAMETERS_VAR, "%TYPE_PARAMETERS%")
        .Replace(GENERIC_CLASS_BODY_VAR, "%BODY%");
        }

        // Add a template for generating a C# property that implements INotifyPropertyChanged
        private const string NOTIFY_PROPERTY_TEMPLATE = "private %PROPERTY_TYPE% _%PROPERTY_NAME%;\npublic %PROPERTY_TYPE% %PROPERTY_NAME%\n{\n    get { return _%PROPERTY_NAME%; }\n    set { _%PROPERTY_NAME% = value; OnPropertyChanged(\"%PROPERTY_NAME%\"); }\n}\n\npublic event PropertyChangedEventHandler PropertyChanged;\nprotected void OnPropertyChanged(string propertyName)\n{\n    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));\n}";
        private const string NOTIFY_PROPERTY_TYPE_VAR = "%PROPERTY_TYPE%";
        private const string NOTIFY_PROPERTY_NAME_VAR = "%PROPERTY_NAME%";
        private void AddNotifyPropertyTemplate(string propertyName, Dictionary<string, string> commands)
        {
        commands[$"create a {propertyName} property that implements INotifyPropertyChanged"] = NOTIFY_PROPERTY_TEMPLATE.Replace(NOTIFY_PROPERTY_TYPE_VAR, "%PROPERTY_TYPE%")
        .Replace(NOTIFY_PROPERTY_NAME_VAR, propertyName);
        }



        private void UpdateCommandsConfigFile(Dictionary<string, string> commands)
        {
            var lines = new List<string>();
            foreach (var entry in commands)
            {
                lines.Add($"{entry.Key}:{entry.Value}");
            }

            File.WriteAllLines("commands.config", lines.ToArray());
        }

        private Dictionary<string, string> LoadCommandsFromConfigFile(string filename = "commands.config")
        {
            // Load the commands from the configuration file
            var commands = new Dictionary<string, string>();
            var configFile = File.ReadAllLines(filename);
            foreach (var line in configFile)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    commands[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return commands;
        }


    }

}
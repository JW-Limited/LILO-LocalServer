using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABLibary;

namespace srvlocal_gui.LAB.HELPER
{
    internal class FormsHandler
    {
        public string Dir { get; private set; }

        public FormsHandler(string directory)
        {
            Dir = directory;
        }

        public void Add(string formName)
        {
            var formTemplates = new Templates.Forms(formName);
            File.WriteAllText(Path.Combine(Dir, $"{formName.ToLower()}.cs"), formTemplates.Basic());
            File.WriteAllText(Path.Combine(Dir, $"{formName.ToLower()}.Designer.cs"), formTemplates.Designer());
        }

        public void Remove(string formName)
        {
            File.Delete(Path.Combine(Dir, $"{formName.ToLower()}.cs"));
            File.Delete(Path.Combine(Dir, $"{formName.ToLower()}.Designer.cs"));
        }

        public void Rename(string oldFormName, string newFormName)
        {
            var oldCsPath = Path.Combine(Dir, $"{oldFormName.ToLower()}.cs");
            var newCsPath = Path.Combine(Dir, $"{newFormName.ToLower()}.cs");
            var oldDesignerPath = Path.Combine(Dir, $"{oldFormName.ToLower()}.Designer.cs");
            var newDesignerPath = Path.Combine(Dir, $"{newFormName.ToLower()}.Designer.cs");

            if (File.Exists(oldCsPath) && File.Exists(oldDesignerPath))
            {
                File.Move(oldCsPath, newCsPath);
                File.Move(oldDesignerPath, newDesignerPath);
            }
            else
            {
                throw new FileNotFoundException("One or both of the form files does not exist.");
            }
        }

        public void Edit(string formName, string formCode, string designerCode)
        {
            var formFile = Dir + $"\\{formName.ToLower()}.cs";
            var designerFile = Dir + $"\\{formName.ToLower()}.Designer.cs";

            if (File.Exists(formFile) && File.Exists(designerFile))
            {
                File.WriteAllText(formFile, formCode);
                File.WriteAllText(designerFile, designerCode);
            }
            else
            {
                throw new Exception("Unable to find files to edit.");
            }
        }   

        public List<string> GetAllFormNames()
        {
            var formNames = new List<string>();

            foreach (var file in Directory.GetFiles(Dir, "*.cs"))
            {
                var formName = Path.GetFileNameWithoutExtension(file);
                formNames.Add(formName);
            }

            return formNames;
        }

        public bool FormExists(string formName)
        {
            return File.Exists(Path.Combine(Dir, $"{formName.ToLower()}.cs")) && File.Exists(Path.Combine(Dir, $"{formName.ToLower()}.Designer.cs"));
        }
    }

}

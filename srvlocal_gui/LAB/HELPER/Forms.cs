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
        public string dir = string.Empty;   

        public FormsHandler(string Directory)
        {
            this.dir = Directory;
        }

        public void Add(string _formName)
        {
            var temp = new Templates.Forms(_formName);

            File.WriteAllText(dir + $"\\{_formName.ToLower()}.cs",temp.Basic());
            File.WriteAllText(dir + $"\\{_formName.ToLower()}.Designer.cs", temp.Designer());
        }
    }
}

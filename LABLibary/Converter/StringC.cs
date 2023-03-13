using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABLibary
{
    public class StringC
    {
        public static string StrArrayToString(string[] str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str2 in str)
            {
                sb.AppendLine(str2);
            }
            return sb.ToString();
        }
    }
}

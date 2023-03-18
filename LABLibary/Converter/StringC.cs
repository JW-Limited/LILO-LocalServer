using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABLibary.Converter
{
    public class StringC
    {
        public static int AppLine = 0;

        public static string StrArrayToString(string[] str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str2 in str)
            {
                if (str2 != string.Empty && str2 != "" && str2 != " ") sb.AppendLine(str2);
            }
            return sb.ToString();
        }

        public static string StrArrayToNumString(string[] str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string sb1 in str)
            {
                if (sb1 == string.Empty || sb1 == "" || sb1 == " ") continue;
                else if (sb1 != "")
                {
                    AppLine++;
                    sb.AppendLine(AppLine + " : " + sb1);
                }
            }

            return sb.ToString();
        }
    }
}

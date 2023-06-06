using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal.auto_generators
{
    internal class GenerateErrorHtml
    {
        private static object _lock = new object();
        private static GenerateErrorHtml _instance;

        public static GenerateErrorHtml Instance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GenerateErrorHtml();
                }

                return _instance;
            }
        }

        private GenerateErrorHtml()
        {

        }

        public string v1(HttpStatusCode statusCode, string msg)
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append($"<title>Error {(int)statusCode}</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/rec/ico/error.png\">");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<h1>Error</h1>");
            sb.Append($"<p>{(int)statusCode} {statusCode}</p>");
            sb.Append($"<div><p>{msg}</p></div>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

    }
}

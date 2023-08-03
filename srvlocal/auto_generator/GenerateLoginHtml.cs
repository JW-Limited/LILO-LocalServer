using srvlocal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal.auto_generators
{
    internal class GenerateLoginHtml
    {
        private static object _lock = new object();
        private static GenerateLoginHtml _instance;

        public static GenerateLoginHtml Instance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GenerateLoginHtml();
                }

                return _instance;
            }
        }

        private GenerateLoginHtml()
        {

        }
        public string v1()
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>Login Page</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/favlogo.png\">");
            sb.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"/css/login.css\">");
            sb.Append("<script src=\"/js/login-actions.js\"></script>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<div class='login-form'>");
            sb.Append("<h1>API Login</h1>");
            sb.Append("<form>");
            sb.Append("<label for='username'>Username:</label>");
            sb.Append("<input type='text' id='username' name='username' placeholder='Enter your username'>");
            sb.Append("<label for='password'>Password:</label>");
            sb.Append("<input type='password' id='password' name='password' placeholder='Enter your password'>");
            sb.Append("<input type='button' class='submit-button' value='Login' onclick='verifyPassword()'>");
            sb.Append("</form>");
            sb.Append("</div>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

    }
}

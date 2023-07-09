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

            // Add modern CSS styling
            sb.Append("<style>");
            sb.Append("body {");
            sb.Append("  font-family: 'Roboto', sans-serif;");
            sb.Append("  background-color: #fafafa;");
            sb.Append("}");
            sb.Append(".login-form {");
            sb.Append("  margin: 0 auto;");
            sb.Append("  width: 400px;");
            sb.Append("  margin-top: 5rem;");
            sb.Append("  padding: 2rem;");
            sb.Append("  background-color: #fff;");
            sb.Append("  border-radius: 8px;");
            sb.Append("  box-shadow: 0px 0px 20px 0px rgba(0, 0, 0, 0.1);");
            sb.Append("}");
            sb.Append("h1 {");
            sb.Append("  font-size: 2rem;");
            sb.Append("  margin-top: 0;");
            sb.Append("  margin-bottom: 1rem;");
            sb.Append("  text-align: center;");
            sb.Append("}");
            sb.Append("label {");
            sb.Append("  display: block;");
            sb.Append("  font-size: 1.2rem;");
            sb.Append("  margin-bottom: 0.5rem;");
            sb.Append("}");
            sb.Append("input[type=\"text\"], input[type=\"password\"] {");
            sb.Append("  padding: 8px;");
            sb.Append("  width: 100%;");
            sb.Append("  margin-bottom: 1rem;");
            sb.Append("  font-size: 1.2rem;");
            sb.Append("  border: 1px solid #ddd;");
            sb.Append("  border-radius: 4px;");
            sb.Append("}");
            sb.Append(".submit-button {");
            sb.Append("  background-color: #4CAF50;");
            sb.Append("  border: none;");
            sb.Append("  color: white;");
            sb.Append("  padding: 8px 16px;");
            sb.Append("  text-align: center;");
            sb.Append("  text-decoration: none;");
            sb.Append("  display: inline-block;");
            sb.Append("  font-size: 14px;");
            sb.Append("  margin-top: 1rem;");
            sb.Append("  margin-bottom: 0;");
            sb.Append("  border-radius: 4px;");
            sb.Append("  cursor: pointer;");
            sb.Append("}");
            sb.Append(".submit-button:hover {");
            sb.Append("  background-color: #3e8e41;");
            sb.Append("}");
            sb.Append("</style>");
            sb.Append("<script>\r\nfunction verifyPassword() {\r\n    var username = document.getElementById('username').value;\r\n    var password = document.getElementById('password').value;\r\n    \r\n    // Check if password is correct\r\n    if (username === 'admin' && password === 'lilodev420') {\r\n        \r\n        window.location.href = '/api/home';\r\n    } else {\r\n        alert('Invalid username or password.');\r\n    }\r\n}\r\n</script>");

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

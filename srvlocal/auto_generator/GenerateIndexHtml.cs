using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal.auto_generators
{
    internal class GenerateIndexHtml
    {
        private static object _lock = new object();
        private static GenerateIndexHtml _instance;

        public static GenerateIndexHtml Instance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GenerateIndexHtml();
                }

                return _instance;
            }
        }

        private GenerateIndexHtml()
        {

        }

        public string v1(string reqDirectory)
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>Index of Files</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/favlogo.png\">");

            // Add modern CSS styling
            sb.Append("<style>");
            sb.Append("body {");
            sb.Append("  font-family: 'Roboto', sans-serif;");
            sb.Append("  background-color: #fafafa;");
            sb.Append("}");
            sb.Append("h1 {");
            sb.Append("  font-size: 2rem;");
            sb.Append("  margin-top: 2rem;");
            sb.Append("  margin-bottom: 1rem;");
            sb.Append("}");
            sb.Append("table {");
            sb.Append("  border-collapse: collapse;");
            sb.Append("  width: 100%;");
            sb.Append("}");
            sb.Append("table th, table td {");
            sb.Append("  border: 1px solid #ddd;");
            sb.Append("  padding: 8px;");
            sb.Append("  text-align: left;");
            sb.Append("}");
            sb.Append("table th {");
            sb.Append("  background-color: #f2f2f2;");
            sb.Append("}");
            sb.Append(".download-link {");
            sb.Append("  background-color: #4CAF50;");
            sb.Append("  border: none;");
            sb.Append("  color: white;");
            sb.Append("  padding: 8px 16px;");
            sb.Append("  text-align: center;");
            sb.Append("  text-decoration: none;");
            sb.Append("  display: inline-block;");
            sb.Append("  font-size: 14px;");
            sb.Append("  margin-right: 8px;");
            sb.Append("  border-radius: 4px;");
            sb.Append("  cursor: pointer;");
            sb.Append("}");
            sb.Append(".download-link:hover {");
            sb.Append("  background-color: #3e8e41;");
            sb.Append("}");
            sb.Append("</style>");

            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>Index of Directory : {reqDirectory.Replace("C:\\LILO\\", "")}</h1>");
            sb.Append("<table>");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th>Name</th>");
            sb.Append("<th>Size</th>");
            sb.Append("<th>Last Modified</th>");
            sb.Append("<th>Download</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            var currentDirectory = new DirectoryInfo(reqDirectory);
            var parentDirectory = currentDirectory.Parent;

            if (parentDirectory != null)
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href='../'>../</a></td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("</tr>");
            }

            foreach (var directory in currentDirectory.GetDirectories())
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href='{directory.Name}/'>{directory.Name}/</a></td>");
                sb.Append("<td></td>");
                sb.Append($"<td>{directory.LastWriteTime}</td>");
                sb.Append("<td></td>");
                sb.Append("</tr>");
            }

            foreach (var file in currentDirectory.GetFiles())
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href='{file.Name}'>{file.Name}</a></td>");
                sb.Append($"<td>{GetSizeString(file.Length)}</td>");
                sb.Append($"<td>{file.LastWriteTime}</td>");
                sb.Append("<td>");
                sb.Append($"<a class='download-link' href='{file.Name}' download>Download</a>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

        private string GetSizeString(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }
            return $"{size} {sizes[order]}";
        }
    
    }
}

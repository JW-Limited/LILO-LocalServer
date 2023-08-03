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

        public string GetSizeString(long size)
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

        public static void SetInstance(object instance)
        {
            _instance = (GenerateIndexHtml)instance;
        }

        public string MicrosoftWordWrapper(string filePath)
        {
            var sb = new StringBuilder();
            var info = new FileInfo(filePath);
            string[] fileContent = File.ReadAllLines(filePath);

            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<title>Text File Viewer</title>");
            sb.Append("<link rel=\"stylesheet\" href=\"/css/word-wrapper.css\">");
            sb.Append("<link href=\"https://cdn.quilljs.com/1.3.6/quill.snow.css\" rel=\"stylesheet\"><link href=\"https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600;700&display=swap\" rel=\"stylesheet\">");
            sb.Append("</head>");
            sb.Append("<body>");

            sb.Append("<div class='header'>");
            sb.Append("<h1>Text File Viewer<small class=\"app-name-subtitle\"> (Beta)\r\n          </small></h1>");

            // File information



            sb.Append("</div>");

            sb.Append("<div class='content'>");


            sb.Append("<div id='editor'></div>");


            sb.Append("<div class='file-info'>");
            sb.Append("<p>File Name: " + info.Name + "</p>");
            sb.Append("<p>File Size: " + GetSizeString(info.Length) + "</p>");
            sb.Append("<p>Last Modified: " + info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss") + "</p>");
            sb.Append("<button class='open-in-text-editor' onclick='openInTextEditor()'>Open in Text Editor</button>");
            sb.Append("</div>");

            sb.Append("</div>");

            sb.Append("<script src=\"https://cdn.quilljs.com/1.3.6/quill.js\"></script>");
            sb.Append("<script src=\"/js/word-wrapper.js\"></script>");
            sb.Append("<script>");
            sb.Append(@"
                        var quill = new Quill('#editor', 
                        {
                            theme: 'snow'
                        });

                        var fileContent = " + Newtonsoft.Json.JsonConvert.SerializeObject(string.Join("\n", fileContent)) + @";
                        quill.root.innerHTML = fileContent;

                    ");
            sb.Append("</script>");

            sb.Append("</body>");
            sb.Append("</html>");

            return sb.ToString();
        }





        public string v1(string reqDirectory)
        {
            var sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset=\"UTF-8\">");
            sb.Append("<title>Index of Files</title>");
            sb.Append("<link rel=\"icon\" type=\"image/png\" sizes=\"32x32\" href=\"/images/favlogo.png\">");

            sb.Append("<link rel=\"stylesheet\" href=\"/css/styles.css\">");
            sb.Append("<link rel=\"stylesheet\" href=\"/css/winui-style.css\">");
            sb.Append("<link href=\"https://cdn.jsdelivr.net/npm/bootstrap-icons@1.6.0/font/bootstrap-icons.css\" rel=\"stylesheet\">");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<header class=\"header\">\r\n  " +
                    $"<h1>srvlocal index" +
                    $"  <small class=\"app-name-subtitle\"> ({reqDirectory.Replace("C:\\LILO\\", "")})\r\n        " +
                    $"  </small>" +
                    $"</h1>\r\n <div class=\"header-right\">\r\n    <div class=\"search-bar\">\r\n      <input type=\"text\" id=\"searchInput\" placeholder=\"Search files...\">\r\n      <button id=\"searchButton\"><i class=\"bi bi-search\"></i></button>\r\n    </div> " +
                    $"<div>\r\n    " +
                    $"  <button class=\"button secondary\" id=\"addFileButton\"><i class=\"bi bi-plus\"></i></button>\r\n    <button class=\"button secondary\"><i class=\"bi bi-three-dots-vertical\"></i></button>\r\n" +
                    
                    $"</div> " +
                $"</header>");
            sb.Append("<div class=\"content\">");
            sb.Append("<nav>");
            sb.Append("<ul class=\"breadcrumb\">");
            sb.Append("<li><a href=\"/\">Home</a></li>");

            var currentDirectory = new DirectoryInfo(reqDirectory);
            var directories = currentDirectory.FullName.Split(Path.DirectorySeparatorChar);

            string path = string.Empty;
            foreach (var directory in directories)
            {
                if (!string.IsNullOrEmpty(directory))
                {
                    path += directory + Path.DirectorySeparatorChar;
                    sb.Append($"<li><a href=\"/{path}\">{directory}</a></li>");
                }
            }

            sb.Append("</ul>");
            sb.Append("</nav>");

            sb.Append("<table class=\"table\">");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<th>Name</th>");
            sb.Append("<th>Size</th>");
            sb.Append("<th>Last Modified</th>");
            sb.Append("<th>Download</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            var parentDirectory = currentDirectory.Parent;

            if (parentDirectory   != null)
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href=\"../\"><i class=\"bi bi-arrow-up\"></i> Parent Directory</a></td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("</tr>");
            }

            foreach (var directory in currentDirectory.GetDirectories())
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href=\"{directory.Name}/\"><i class=\"bi bi-folder\"></i> {directory.Name}/</a></td>");
                sb.Append("<td></td>");
                sb.Append($"<td>{directory.LastWriteTime}</td>");
                sb.Append("<td></td>");
                sb.Append("</tr>");
            }

            foreach (var file in currentDirectory.GetFiles())
            {
                sb.Append("<tr>");
                sb.Append($"<td><a href=\"{file.Name}\"><i class=\"bi bi-file-binary-fill\"></i> {file.Name}</a></td>");
                sb.Append($"<td>{GetSizeString(file.Length)}</td>");
                sb.Append($"<td>{file.LastWriteTime}</td>");
                sb.Append("<td>");
                sb.Append($"<a class=\"download-link\" href=\"{file.Name}\" download><i class=\"bi bi-download\"></i> Sync</a>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");
            sb.Append("</body>");
            sb.Append("<script src=\"/js/index-action.js\"  nonce=\"random-nonce\"></script>");
            sb.Append("</html>");
            return sb.ToString();
        }

        
    }
}

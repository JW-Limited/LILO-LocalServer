using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Local;
public class MediaServer
{
    private HttpListener _listener;
    private  readonly string _mediaFolder;
    public bool _isRunning;
    public int _port = 10890;

    public MediaServer()
    {
        _listener = new HttpListener();
       
        _listener.Prefixes.Add($"http://localhost:{_port}/");
        _mediaFolder = Local.Server.mediaDirectory;
        _isRunning = false;
    }

    public void Start()
    {
        _listener.Start();
        _isRunning = true;
        
        Console.WriteLine($"Media server started at http://localhost:{_port}/");

        Thread thread = new Thread(HandleRequests);
        thread.Start();
    }

    public void Stop()
    {
        _listener.Stop();
        _isRunning = false;

        Console.WriteLine("Media server stopped.");
    }

    public class GenerateMediaSearchPage
    {
        private readonly string _mediaFolder;

        public GenerateMediaSearchPage(string mediaFolder)
        {
            _mediaFolder = mediaFolder;
        }

        public void WriteSearchPage(HttpListenerResponse response)
        {
            response.StatusCode = (int)HttpStatusCode.OK;
            response.ContentType = "text/html";

            using (var writer = new StreamWriter(response.OutputStream))
            {
                writer.WriteLine("<!DOCTYPE html>");
                writer.WriteLine("<html>");
                writer.WriteLine("<head>");
                writer.WriteLine("<title>Media Search</title>");
                writer.WriteLine("<style>");
                writer.WriteLine("body {");
                writer.WriteLine("    background: linear-gradient(to right, #667eea, #764ba2);");
                writer.WriteLine("    font-family: Arial, sans-serif;");
                writer.WriteLine("    margin: 0;");
                writer.WriteLine("    padding: 0;");
                writer.WriteLine("}");
                writer.WriteLine("header {");
                writer.WriteLine("    text-align: center;");
                writer.WriteLine("    padding: 20px 0;");
                writer.WriteLine("}");
                writer.WriteLine("h1 {");
                writer.WriteLine("    color: #fff;");
                writer.WriteLine("}");
                writer.WriteLine("main {");
                writer.WriteLine("    max-width: 600px;");
                writer.WriteLine("    margin: 0 auto;");
                writer.WriteLine("    padding: 20px;");
                writer.WriteLine("}");
                writer.WriteLine("form {");
                writer.WriteLine("    display: flex;");
                writer.WriteLine("}");
                writer.WriteLine("label {");
                writer.WriteLine("    color: #fff;");
                writer.WriteLine("    font-size: 18px;");
                writer.WriteLine("    margin-right: 10px;");
                writer.WriteLine("}");
                writer.WriteLine("input[type='text'] {");
                writer.WriteLine("    flex: 1;");
                writer.WriteLine("    padding: 8px;");
                writer.WriteLine("    font-size: 16px;");
                writer.WriteLine("    border: none;");
                writer.WriteLine("    border-radius: 4px;");
                writer.WriteLine("}");
                writer.WriteLine("button {");
                writer.WriteLine("    padding: 8px 16px;");
                writer.WriteLine("    font-size: 16px;");
                writer.WriteLine("    background-color: #4CAF50;");
                writer.WriteLine("    color: #fff;");
                writer.WriteLine("    border: none;");
                writer.WriteLine("    border-radius: 4px;");
                writer.WriteLine("    cursor: pointer;");
                writer.WriteLine("}");
                writer.WriteLine("ul {");
                writer.WriteLine("    list-style-type: none;");
                writer.WriteLine("    padding: 0;");
                writer.WriteLine("}");
                writer.WriteLine("li {");
                writer.WriteLine("    margin: 10px 0;");
                writer.WriteLine("    transition: transform 0.3s ease-in-out;");
                writer.WriteLine("}");
                writer.WriteLine("li:hover {");
                writer.WriteLine("    transform: scale(1.1);");
                writer.WriteLine("}");
                writer.WriteLine("a {");
                writer.WriteLine("    color: #fff;");
                writer.WriteLine("    text-decoration: none;");
                writer.WriteLine("}");
                writer.WriteLine("footer {");
                writer.WriteLine("    text-align: center;");
                writer.WriteLine("    padding: 20px 0;");
                writer.WriteLine("    color: #fff;");
                writer.WriteLine("}");
                writer.WriteLine("</style>");
                writer.WriteLine("<script>");
                writer.WriteLine("document.addEventListener('DOMContentLoaded', function() {");
                writer.WriteLine("    var form = document.querySelector('.form');");
                writer.WriteLine("    var searchInput = document.getElementById('search');");
                writer.WriteLine("    var fileList = document.querySelector('ul');");
                writer.WriteLine("    var files = Array.from(fileList.getElementsByTagName('li'));");
                writer.WriteLine("    ");
                writer.WriteLine("    form.addEventListener('submit', function(event) {");
                writer.WriteLine("        event.preventDefault();");
                writer.WriteLine("        var searchTerm = searchInput.value.toLowerCase();");
                writer.WriteLine("        files.forEach(function(file) {");
                writer.WriteLine("            var fileName = file.textContent.toLowerCase();");
                writer.WriteLine("            if (fileName.includes(searchTerm)) {");
                writer.WriteLine("                file.style.display = 'block';");
                writer.WriteLine("            } else {");
                writer.WriteLine("                file.style.display = 'none';");
                writer.WriteLine("            }");
                writer.WriteLine("        });");
                writer.WriteLine("    });");
                writer.WriteLine("    ");
                writer.WriteLine("    files.forEach(function(file) {");
                writer.WriteLine("        file.addEventListener('click', function() {");
                writer.WriteLine("            var fileUrl = file.querySelector('a').getAttribute('href');");
                writer.WriteLine("            window.open(fileUrl, '_blank');");
                writer.WriteLine("        });");
                writer.WriteLine("    });");
                writer.WriteLine("});");
                writer.WriteLine("</script>");
                writer.WriteLine("</head>");
                writer.WriteLine("<body>");
                writer.WriteLine("<header>");
                writer.WriteLine("<h1>Media Search</h1>");
                writer.WriteLine("</header>");
                writer.WriteLine("<main>");
                writer.WriteLine("<form class='form'>");
                writer.WriteLine("<label for='search'>Search:</label>");
                writer.WriteLine("<input type='text' id='search' name='search' placeholder='Enter search keyword'/>");
                writer.WriteLine("<button type='submit'>Search</button>");
                writer.WriteLine("</form>");
                writer.WriteLine("<ul>");

                var mediaFiles = Directory.EnumerateFiles(_mediaFolder, "*.*", SearchOption.AllDirectories)
                    .Where(f => f.EndsWith(".mp3") || f.EndsWith(".mp4"));

                foreach (var mediaFile in mediaFiles)
                {
                    writer.WriteLine($"<li><a href='{mediaFile}'>{Path.GetFileName(mediaFile)}</a></li>");
                }

                writer.WriteLine("</ul>");
                writer.WriteLine("</main>");
                writer.WriteLine("<footer>");
                writer.WriteLine("<p>Created with LOVE by <a target='_blank' href='https://jwlmt.com'>JW Lmt.</a> - &copy; 2023</p>");
                writer.WriteLine("</footer>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }
        }
    }
    public class GenerateSearchHtml
    {
        string mediaRoot = null;

        public GenerateSearchHtml(string mediaR)
        {
            mediaRoot = mediaR;
        }

        public string GetHtml(string searchQuery)
        {
            // Create a StringBuilder to hold the HTML
            StringBuilder html = new StringBuilder();

            // Add the HTML head
            html.Append("<!DOCTYPE html>");
            html.Append("<html>");
            html.Append("<head>");
            html.Append("<title>Media Search</title>");
            html.Append("</head>");

            // Add the HTML body
            html.Append("<body>");
            html.Append("<h1>Media Search</h1>");

            // Add the search form
            html.Append("<form method='get' action='/search'>");
            html.Append("<label for='searchQuery'>Search:</label>");
            html.Append("<input type='text' id='searchQuery' name='searchQuery' value='" + searchQuery + "'>");
            html.Append("<input type='submit' value='Search'>");
            html.Append("</form>");

            // Add the search results
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Search for media files that match the search query
                string[] mediaFiles = Directory.GetFiles(mediaRoot, "*" + searchQuery + "*", SearchOption.AllDirectories);

                if (mediaFiles.Length > 0)
                {
                    html.Append("<h2>Search Results</h2>");
                    html.Append("<ul>");

                    foreach (string mediaFile in mediaFiles)
                    {
                        html.Append("<li><a href='" + mediaFile + "'>" + Path.GetFileName(mediaFile) + "</a></li>");
                    }

                    html.Append("</ul>");
                }
                else
                {
                    html.Append("<p>No results found.</p>");
                }
            }

            html.Append("</body>");
            html.Append("</html>");

            return html.ToString();
        }
    }


    private void HandleRequests()
    {
        while (_isRunning)
        {
            HttpListenerContext context = _listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string filename = request.Url.AbsolutePath;
            filename = filename.Substring(1);
            var filePath = Path.Combine(_mediaFolder, request.Url.LocalPath.TrimStart('/'));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[LILO sMEDIA - " + DateTime.UtcNow + "] : {0} request for: {1}", request.HttpMethod, filename);
            Console.ForegroundColor = ConsoleColor.White;
            if (request.Url.AbsolutePath == "/search/v1")
            {
                var search = new GenerateSearchHtml(_mediaFolder);
                
                var searchpage = search.GetHtml("Delilah");
                var content = Encoding.UTF8.GetBytes(searchpage);
                response.ContentLength64 = content.Length;
                response.OutputStream.Write(content, 0, content.Length);
            }
            else if (request.Url.AbsolutePath == "/search/v2")
            {
                var search = new GenerateMediaSearchPage(_mediaFolder);
                search.WriteSearchPage(response);
            }

            else if (File.Exists(_mediaFolder + filename))
            {
                if (request.HttpMethod == "GET")
                {

                    if (request.Url.LocalPath.EndsWith(".mp3") || request.Url.LocalPath.EndsWith(".wav") || request.Url.LocalPath.EndsWith(".ogg"))
                    {
                        try
                        {
                            StreamAudio(request, response);
                        }
                        catch(Exception ex)
                        {
                            GenerateErrorHtml(HttpStatusCode.InternalServerError, ex.Message) ;
                        }
                    }
                    else
                    {
                        try
                        {
                            byte[] buffer = File.ReadAllBytes(_mediaFolder + filename);
                            response.ContentLength64 = buffer.Length;
                            response.OutputStream.Write(buffer, 0, buffer.Length);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes("This server only accept GET requests.");
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
            }
            else
            {
                var indexHtml = GenerateErrorHtml(HttpStatusCode.NotFound,filePath);
                var content = Encoding.UTF8.GetBytes(indexHtml);
                response.ContentLength64 = content.Length;
                response.OutputStream.Write(content, 0, content.Length);
            }

            response.OutputStream.Close();
        }
    }

    private string GenerateErrorHtml(HttpStatusCode statusCode, string msg)
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

    private void Send404(HttpListenerResponse response)
    {
        response.StatusCode = (int)HttpStatusCode.NotFound;
        response.StatusDescription = "Not Found";
        var indexHtml = GenerateErrorHtml(HttpStatusCode.NotFound, "");
        var content = Encoding.UTF8.GetBytes(indexHtml);
        response.ContentLength64 = content.Length;
        response.OutputStream.Write(content, 0, content.Length);
    }


    private void StreamAudio(HttpListenerRequest request, HttpListenerResponse response)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"[LILO SERVER - {DateTime.UtcNow}] : STREAMING {request.Url}");
        Console.ForegroundColor = ConsoleColor.White;

        string filename = request.Url.AbsolutePath;
        filename = filename.Substring(1);

        string audioFile = _mediaFolder + filename;
        if (Path.GetExtension(audioFile).ToLower() != ".mp3" &&
            Path.GetExtension(audioFile).ToLower() != ".wav" &&
            Path.GetExtension(audioFile).ToLower() != ".ogg")
        {
            Send404(response);
            return;
        }
        if (!File.Exists(audioFile))
        {
            Send404(response);
            return;
        }
        using (FileStream audioStream = new FileStream(audioFile, FileMode.Open))
        {
            response.ContentType = "audio/" + Path.GetExtension(audioFile).ToLower().Substring(1);
            response.ContentLength64 = audioStream.Length;
            response.SendChunked = true;
            byte[] buffer = new byte[1024 * 16];
            int read;
            while ((read = audioStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                response.OutputStream.Write(buffer, 0, read);
                response.OutputStream.Flush();
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal;
public class SearchSideGenerator
{
    public string Directory
    {
        get; set;
    }

    public SearchSideGenerator(string directory)
    {
        Directory = directory;
    }

    public string GenerateHTML()
    {
        var html = new StringBuilder();

        html.AppendLine("<div class='search-container'>");
        html.AppendLine("<form>");
        html.AppendLine("<input type='text' id='search' placeholder='Search..'>");
        html.AppendLine("<button type='submit'><i class='fa fa-search'></i></button>");
        html.AppendLine("</form>");
        html.AppendLine("</div>");

        return html.ToString();
    }

    public string GenerateJavaScript()
    {
        var js = new StringBuilder();

        js.AppendLine("<script>");
        js.AppendLine("var search = document.getElementById('search');");
        js.AppendLine("search.addEventListener('keyup', function() {");
        js.AppendLine("var value = search.value.toLowerCase();");
        js.AppendLine("var files = document.getElementsByClassName('file');");
        js.AppendLine("for (var i = 0; i < files.length; i++) {");
        js.AppendLine("var file = files[i];");
        js.AppendLine("var fileName = file.textContent.toLowerCase();");
        js.AppendLine("if (fileName.includes(value)) {");
        js.AppendLine("file.style.display = 'block';");
        js.AppendLine("} else {");
        js.AppendLine("file.style.display = 'none';");
        js.AppendLine("}");
        js.AppendLine("}");
        js.AppendLine("});");
        js.AppendLine("</script>");

        return js.ToString();
    }

    public string GenerateCSS()
    {
        var css = new StringBuilder();

        css.AppendLine(".search-container {");
        css.AppendLine("width: 100%;");
        css.AppendLine("}");
        css.AppendLine("form {");
        css.AppendLine("display: flex;");
        css.AppendLine("}");
        css.AppendLine("input {");
        css.AppendLine("flex: 1;");
        css.AppendLine("padding: 8px;");
        css.AppendLine("}");
        css.AppendLine("button {");
        css.AppendLine("padding: 8px;");
        css.AppendLine("}");

        return css.ToString();
    }

    public string GenerateFileList(List<string> files)
    {
        var fileList = new StringBuilder();

        fileList.AppendLine("<ul class='file-list'>");

        foreach (var file in files)
        {
            fileList.AppendLine("<li class='file'>" + file + "</li>");
        }

        fileList.AppendLine("</ul>");

        return fileList.ToString();
    }

}

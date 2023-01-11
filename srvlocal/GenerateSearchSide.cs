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

        html.Append("<div class='search-container'>");
        html.Append("<form>");
        html.Append("<input type='text' id='search' placeholder='Search..'>");
        html.Append("<button type='submit'><i class='fa fa-search'></i></button>");
        html.Append("</form>");
        html.Append("</div>");

        return html.ToString();
    }

    public string GenerateJavaScript()
    {
        var js = new StringBuilder();

        js.Append("<script>");
        js.Append("var search = document.getElementById('search');");
        js.Append("search.addEventListener('keyup', function() {");
        js.Append("var value = search.value.toLowerCase();");
        js.Append("var files = document.getElementsByClassName('file');");
        js.Append("for (var i = 0; i < files.length; i++) {");
        js.Append("var file = files[i];");
        js.Append("var fileName = file.textContent.toLowerCase();");
        js.Append("if (fileName.includes(value)) {");
        js.Append("file.style.display = 'block';");
        js.Append("} else {");
        js.Append("file.style.display = 'none';");
        js.Append("}");
        js.Append("}");
        js.Append("});");
        js.Append("</script>");

        return js.ToString();
    }

    public string GenerateCSS()
    {
        var css = new StringBuilder();

        css.Append(".search-container {");
        css.Append("width: 100%;");
        css.Append("}");
        css.Append("form {");
        css.Append("display: flex;");
        css.Append("}");
        css.Append("input {");
        css.Append("flex: 1;");
        css.Append("padding: 8px;");
        css.Append("}");
        css.Append("button {");
        css.Append("padding: 8px;");
        css.Append("}");

        return css.ToString();
    }

    public string GenerateFileList()
    {
        var fileList = new StringBuilder();
        return "nigger";
    }

}

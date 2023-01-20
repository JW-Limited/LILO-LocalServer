using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Local;
public class Errorhandling
{
    public void ThrowError(string msg)
    {
        LogError(msg);
        throw new Exception(msg);
    }

    public void LogError(string error)
    {
        var logEntry = new StringBuilder();
        logEntry.AppendLine($"[{DateTime.Now}] : An Error Accourd : {error}");
        logEntry.AppendLine($"");
        logEntry.AppendLine($"");
        logEntry.AppendLine();

        var logFilePath = Path.Combine(".\\", DateTime.Now.ToString("yyyy-MM-dd") + " error.log");
        File.AppendAllText(logFilePath, logEntry.ToString());
    }

}

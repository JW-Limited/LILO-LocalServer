using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace LILO.JBO
{
    public class StatusSender
    {
        private string _serverUrl = "http://localhost:8080/api/data?key=liloDev-420";
        private readonly string _statusFile = ".\\srvlocal.runtimeconfig.json";
        private readonly string _accountFile = ".\\srvlocal.deps.json";
        private System.Threading.Timer _timer;

        public async Task<string> SendStatus(object state)
        {
            try
            {
                // Read status and account from files
                var status = File.ReadAllText(_statusFile);
                var account = File.ReadAllText(_accountFile);

                // Send status and account to server
                using (var client = new WebClient())
                {
                    var data = new NameValueCollection
            {
                { "status", status },
                { "account", account }
            };
                    var response = client.UploadValues(_serverUrl, "POST", data);
                    return Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
}


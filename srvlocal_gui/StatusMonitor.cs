using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using Telerik.WinControls.UI.Map.Bing;

namespace LILO.JBO
{
    public class StatusSender
    {
        private readonly string _serverUrl = "http://localhost:8080/api/data?key=liloDev-420";
        private readonly string _statusFile = ".\\srvlocal.runtimeconfig.json";
        private readonly string _accountFile = ".\\srvlocal.deps.json";
        //private System.Threading.Timer _timer;

        public Task<string> SendStatus(object state)
        {
            try
            {
                var status = File.ReadAllText(_statusFile);
                var account = File.ReadAllText(_accountFile);

                using (var client = new WebClient())
                {
                    var data = new NameValueCollection
                    {
                        { "status", status },
                        { "account", account }
                    };
                    var response = client.UploadValues(_serverUrl, "POST", data);
                    return Task.FromResult(Encoding.UTF8.GetString(response));
                }
            }
            catch (Exception ex)
            {
                LABLibary.Forms.ErrorDialog.ErrorManager.AddError(ex.Message, true, "LocalServerAPI");
                return Task.FromResult("Error");
            }
        }
    }
}


using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Telerik.WinControls.UI.Map.Bing;

namespace LILO.JBO
{
    public class StatusSender
    {
        private readonly string _serverUrl = "http://localhost:8080/api/data?key=liloDev-420";
        private readonly string _statusFile = ".\\srvlocal.runtimeconfig.json";
        private readonly string _accountFile = ".\\srvlocal.deps.json";

        public async Task<string> SendStatus(CancellationToken cancellationToken)
        {
            try
            {
                var status = File.ReadAllText(_statusFile);
                var account = File.ReadAllText(_accountFile);

                var data = new
                {
                    status = status,
                    account = account
                };

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(_serverUrl, content, cancellationToken);
                    response.EnsureSuccessStatusCode();
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return responseJson;
                }
            }
            catch (OperationCanceledException ex)
            {
                LABLibary.Forms.ErrorDialog.ErrorManager.AddError("HTTP request was cancelled.", true, "LocalServerAPI");
                return "Cancelled";
            }
            catch (Exception ex)
            {
                LABLibary.Forms.ErrorDialog.ErrorManager.AddError(ex.Message, true, "LocalServerAPI");
                return "Error";
            }
        }
    }

}


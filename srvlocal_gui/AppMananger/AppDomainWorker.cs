using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    public class Worker
    {
        public class AppDomainWorker : MarshalByRefObject
        {

            private static object _lock = new object();
            private static AppDomainWorker _instance = null;

            public static AppDomainWorker Instance
            {
                get
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppDomainWorker();
                        }

                        return _instance;
                    }
                }
            }

            public void PerformWorkInAppDomain(out string domainName)
            {
                AppDomain newDomain = AppDomain.CurrentDomain;
                try
                {

                    var worker = (AppDomainWorker)newDomain.CreateInstanceAndUnwrap(
                        typeof(AppDomainWorker).Assembly.FullName,
                        typeof(AppDomainWorker).FullName);

                    worker.DoWork(newDomain);

                    domainName = newDomain.BaseDirectory;
                }
                catch (Exception ex)
                {
                    domainName = ex.Message;
                }
            }

            public void DoWork(AppDomain appdomain)
            {
                try
                {
                    Logger.Instance.Log("[SECOND DOMAIN] - Created a SubAppDomain...");

                    var process = new Process();
                    process.StartInfo.FileName = ".\\server.exe";
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.Domain = appdomain.FriendlyName;
                    process.EnableRaisingEvents = true;

                    Logger.Instance.Log("[SECOND DOMAIN] - Try to start Messaging Service...");

                    process.Start();

                }
                catch (Exception ex)
                {
                    Logger.Instance.Log("[SECOND DOMAIN] - An exception occurred in the AppDomain: " + ex.Message);
                }
            }

        }
    }
    
}

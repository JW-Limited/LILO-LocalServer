using System;
using System.Collections.Generic;
using Experimental.System.Messaging;

namespace LABLibary.Connect
{
    public class DesktopApi
    {
        private MessageQueue queue = new MessageQueue(".\\private$\\Commands");
        private Message test;
        public static string ApiKey;
        private static DesktopApi _instance;
        public static readonly object _lock = new object();

        public static string Use(string message, string apikey = "liloDev420")
        {
            try
            {
                var api = new DesktopApi();
                ApiKey = apikey;
                api.Start();

                var queue = new MessageQueue(".\\private$\\Chat");

                queue.Authenticate = true;

                queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                queue.Send(message);

                return queue.Receive().ToString();
            }
            catch(Exception ex)
            {
                return $"Error({ex.Message})";
            }
            
        }

        private DesktopApi() {}
        public static DesktopApi Instance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DesktopApi();
                }
            }

            return _instance;
        }

        public void Start()
        {
            var thr = new Thread(RecevMessage);
            thr.Start();
        }

        public void RecevMessage()
        {
            
            while (true)
            {
                try
                {
                    if (queue.GetAllMessages() != null)
                    {
                        Message message = queue.Receive();
                        message = message == null ? null : message;
                        System.Windows.Forms.MessageBox.Show(message.Body.ToString());
                    }
                }
                catch(Exception ex) { System.Console.WriteLine(ex.Message); }
            }

        }

        public void SendMessage(string label, string com) 
        {
            var message = new Message();
            message.Label = label;
            message.Body = $"API?={ApiKey}COMMAND?={com}";

            queue.Send(message);

        }
    }
}

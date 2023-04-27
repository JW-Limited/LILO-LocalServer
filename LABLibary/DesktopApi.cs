using System;
using System.Collections.Generic;
using Experimental.System.Messaging;

namespace LABLibary.Connect
{
    public class DesktopApi
    {
        private MessageQueue queue;
        private Message test;
        public string ApiKey;

        public static string Use(string message)
        {
            try
            {
                var api = new DesktopApi("liloDev420");
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

        public DesktopApi(string apikey) 
        {
            try
            {
                queue = new MessageQueue(".\\private$\\Commands");
                this.ApiKey = apikey;
                queue.Authenticate = true;
            }
            catch (Exception ex)
            {

            }
            
        }

        public void Start()
        {
            var thr = new Thread(RecevMessage);
            thr.Start();
        }

        public void RecevMessage()
        {
            /*
            while (true)
            {
                try
                {
                    if (queue.GetAllMessages() != null)
                    {
                        Message message = queue.Receive();
                        message = message == null ? null : message;
                    }
                }
                catch { }
            }*/

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

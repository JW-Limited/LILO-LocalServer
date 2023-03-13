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

        public DesktopApi(string apikey) 
        {
            queue = new MessageQueue(".\\private$\\Commands");
            this.ApiKey = apikey;
            queue.Authenticate = true;
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
                if(queue.GetAllMessages() != null)
                {
                    Message message = queue.Receive();
                    message = message == null ? null : message;
                }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LABLibary.Interface
{
    public class CommunicationInterface
    {
        Socket Socket1 { get; set; }
        Socket Socket2 { get; set; }

        public CommunicationInterface()
        {
            Socket1 = new Socket(SocketType.Stream, ProtocolType.Tcp);
            Socket2 = new Socket(SocketType.Stream, ProtocolType.Tcp); 
        }

        public void Connect(string host1, int port1, string host2, int port2)  
        {
            Socket1.Connect(host1, port1); 
            Socket2.Connect(host2, port2);
            Socket1.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            Socket2.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
        }

        public void SendData(byte[] data1, byte[] data2) 
        { 
            SendToDefaultBuffer(data1, data2); 
        }

        public void Disconnect() 
        { 
            // Close each socket connection 
            try 
            { 
                if (Socket1 != null)
                    Socket1.Close(); 
            } finally 
            { 
                Socket2.Close(); 
            } 
        }

        public bool IsConnected()
        {
            return Socket1.Connected;
        }

        public void SendToDefaultBuffer(byte[] data1, byte[] data2) 
        { 
            // Send the data over each socket
            Socket1.SendBufferSize = 10024; 
            Socket1.Send(data1); 
            Socket2.SendBufferSize = 10024; 
            Socket2.Send(data2); 
        }

        public string ReceiveFromDefaultBuffer() 
        { 
            // Receive data from each socket
            byte[] serverResponse = new byte[1024]; 
            Socket1.ReceiveBufferSize = 1024; 
            Socket1.Receive(serverResponse); 
            
            byte[] mediaResponse = new byte[1024]; 
            Socket2.ReceiveBufferSize = 1024; 
            Socket2.Receive(mediaResponse); 

            return Convert.ToString(serverResponse) + Convert.ToString(mediaResponse);
        }

        public void ReceiveDataFromAnotherApplication() 
        {
            ReceiveFromDefaultBuffer(); 
        }

        public void SendDataFromAnotherApplication(byte[] data1, byte[] data2)
        {
            SendToDefaultBuffer(data1, data2);
        }
    }
}
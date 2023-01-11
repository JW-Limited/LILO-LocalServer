﻿using System;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Security;

namespace Local;
class ApiToRecevieCommands
{
    private int _port;
    private TcpListener _listener;
    private X509Certificate2 _certificate;
    private static string _username = "admin";
    private static string _password = "password";
    public bool OAuth2 = false;
    public bool certAcepted = false;
    public bool apiListening = false;

    public ApiToRecevieCommands(int port, X509Certificate2 certificate)
    {
        _port = port;
        _certificate = certificate;
    }

    public void Start()
    {
        _listener = new TcpListener(IPAddress.Any, _port);
        try
        {
            _listener.Start();

            apiListening = true;

            while (true)
            {
                using (TcpClient client = _listener.AcceptTcpClient())
                {
                    using (SslStream sslStream = new SslStream(client.GetStream()))
                    {
                        try
                        {
                            sslStream.AuthenticateAsServer(_certificate);
                            certAcepted = true;
                            // check for authentication 
                            string authMessage = ReadMessage(sslStream);
                            if (!IsAuthenticated(authMessage))
                            {
                                sslStream.Write(Encoding.ASCII.GetBytes("Access Denied"));
                                continue;
                            }
                            // authenticated
                            OAuth2 = true;
                            sslStream.Write(Encoding.ASCII.GetBytes("Access granted"));
                            string message = ReadMessage(sslStream);
                            Console.WriteLine("Received: {0}", message);

                            string response = "Work is done";
                            byte[] data = Encoding.ASCII.GetBytes(response);
                            sslStream.Write(data, 0, data.Length);
                        }
                        catch (AuthenticationException e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                            if (e.InnerException != null)
                            {
                                Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                            }
                            Console.WriteLine("Authentication failed - closing the connection.");
                            sslStream.Close();
                            client.Close();
                        }
                    }
                }
            }
        }
        catch (Exception ex) { return; }

        
    }

    public bool IsAuthenticated(string authMessage)
    {
        string[] authParts = authMessage.Split(':');
        return authParts[0] == _username && authParts[1] == _password;
    }

    private string ReadMessage(System.Net.Security.SslStream sslStream)
    {
        byte[] buffer = new byte[2048];
        StringBuilder messageData = new StringBuilder();
        int bytes = -1;
        do
        {
            bytes = sslStream.Read(buffer, 0, buffer.Length);
            Decoder decoder = Encoding.UTF8.GetDecoder();
            char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
            decoder.GetChars(buffer, 0, bytes, chars, 0);
            messageData.Append(chars);

            // Check for end-of-file.
            if (bytes < buffer.Length)
            {
                break;
            }
        } while (sslStream.Length != messageData.Length);

        return messageData.ToString();
    }
}

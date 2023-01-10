using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Local;
public class MediaServer
{
    private HttpListener _listener;
    private  readonly string _mediaFolder;
    public bool _isRunning;
    public int _port = 10890;

    public MediaServer()
    {
        _listener = new HttpListener();
       
        _listener.Prefixes.Add($"https://www.dcn.lilo.com:{_port}/");
        _mediaFolder = "media/";
        _isRunning = false;
    }

    public void Start()
    {
        _listener.Start();
        _isRunning = true;

        Console.WriteLine("Media server started at http://dcn.lilo.com:1080/");

        Thread thread = new Thread(HandleRequests);
        thread.Start();
    }

    public void Stop()
    {
        _listener.Stop();
        _isRunning = false;

        Console.WriteLine("Media server stopped.");
    }

    private void HandleRequests()
    {
        while (_isRunning)
        {
            HttpListenerContext context = _listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string filename = request.Url.AbsolutePath;
            filename = filename.Substring(1);

            Console.WriteLine("{0} request for: {1}", request.HttpMethod, filename);

            if (File.Exists(_mediaFolder + filename))
            {
                if (request.HttpMethod == "GET")
                {
                    byte[] buffer = File.ReadAllBytes(_mediaFolder + filename);
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes("This server only accept GET requests.");
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }
            }
            else
            {
                byte[] buffer = File.ReadAllBytes("404.html");
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }

            response.OutputStream.Close();
        }
    }
}

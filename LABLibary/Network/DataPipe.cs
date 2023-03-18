using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABLibary.Network
{
    public class DataPipe
    {
        private readonly string pipeName;
        private readonly string key;

        public DataPipe(string pipeName, string key)
        {
            this.pipeName = pipeName;
            this.key = key;
        }

        public async Task<string> GetDataAsync()
        {
            using (var pipe = new NamedPipeClientStream(pipeName))
            {
                pipe.Connect();
                var buffer = new byte[1024];
                int bytesRead = await pipe.ReadAsync(buffer, 0, buffer.Length);
                var authKey = Encoding.UTF8.GetString(buffer, 0, 32);
                if (authKey != key)
                {
                    throw new InvalidOperationException("Invalid authentication key");
                }
                return Encoding.UTF8.GetString(buffer, 32, bytesRead - 32);
            }
        }

        public async Task<string> PostDataAsync(string data)
        {
            using (var pipe = new NamedPipeClientStream(pipeName))
            {
                pipe.Connect();
                var authBytes = Encoding.UTF8.GetBytes(key);
                var buffer = Encoding.UTF8.GetBytes(data);
                var combinedBuffer = new byte[authBytes.Length + buffer.Length];
                Array.Copy(authBytes, combinedBuffer, authBytes.Length);
                Array.Copy(buffer, 0, combinedBuffer, authBytes.Length, buffer.Length);
                await pipe.WriteAsync(combinedBuffer, 0, combinedBuffer.Length);
                pipe.WaitForPipeDrain();
                buffer = new byte[1024];
                int bytesRead = await pipe.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
        }
    }
}

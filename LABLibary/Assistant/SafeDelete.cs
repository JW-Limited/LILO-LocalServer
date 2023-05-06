using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABLibary.Assistant
{
    public class SafeDelete
    {
        public static void SafeDeleteFile(string filePath, Action<int> progressCallback = null, Action<string> errorCallback = null)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    errorCallback?.Invoke($"File not found: {filePath}");
                    return;
                }

                long fileSize = new FileInfo(filePath).Length;
                long bytesDeleted = 0;

                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    Random rand = new Random();

                    while (stream.Position < fileSize)
                    {
                        rand.NextBytes(buffer);
                        stream.Write(buffer, 0, buffer.Length);
                        bytesDeleted += buffer.Length;

                        int progressPercentage = (int)((float)bytesDeleted / (float)fileSize * 100);
                        progressCallback?.Invoke(progressPercentage);
                    }
                }


                File.Delete(filePath);

                if (File.Exists(filePath))
                {
                    errorCallback?.Invoke($"Failed to delete File: {filePath}");
                    return;
                }

                progressCallback?.Invoke(100);
            }
            catch (Exception ex)
            {
                errorCallback?.Invoke($"Failed to delete File: {ex.Message}");
            }
        }


    }
}

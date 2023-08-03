using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui
{
	class Program
	{
		public static void GenerateDirectoryContents(string directoryPath)
		{
			if (Directory.Exists(directoryPath))
			{
				Logger.Instance.Log("Directory allready satisfied.");
				return;
			}

			string[] directories = directoryPath.Split(Path.DirectorySeparatorChar);

			string currentPath = "";
			foreach (string directory in directories)
			{
				currentPath = Path.Combine(currentPath, directory);
				if (!Directory.Exists(currentPath))
				{
					Logger.Instance.Log("Generated directory: " + currentPath);
					Directory.CreateDirectory(currentPath);
				}
			}
		}

		private static object _lockRequest = new object();

		public static string MakeGetRequest(string url)
		{
			lock (_lockRequest)
			{
				try
				{
					using (var client = new WebClient())
					{
						string response = client.DownloadString(url);
						return response;
					}
				}
				catch (Exception ex)
				{
					return $"Error occurred while making the GET request: {ex.Message}";
				}
			}
		}

		public static bool CheckIfDirIsValid()
		{
			string[] requiredFiles = { "srvlocal.exe", "srvlocal.dll", "srvlocal.runtimeconfig.json" };
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

			return requiredFiles.All(file => File.Exists(Path.Combine(baseDirectory, file)));
		}

		public static void DeleteFiles()
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

			foreach (string file in Directory.GetFiles(baseDirectory))
			{
				File.Delete(file);
			}
		}

		public static void CreateDirectoryIfNotExists()
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

			if (!Directory.Exists(baseDirectory))
			{
				Directory.CreateDirectory(baseDirectory);
			}
		}

		public static List<string> GetMissingFiles()
		{
			string[] requiredFiles = { "srvlocal.exe", "srvlocal.dll", "srvlocal.runtimeconfig.json" };
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

			return requiredFiles.Where(file => !File.Exists(Path.Combine(baseDirectory, file))).ToList();
		}
	}
}

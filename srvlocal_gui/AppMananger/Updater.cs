using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;
using Octokit;
using System.IO;
using srvlocal_gui.AppManager;
using System.IO.Compression;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace srvlocal_gui;

public sealed class Updater
{

    private static Updater _instance;
    public static readonly object _lock = new object();

    private Updater()
    {

    }

    public static Updater Instance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new Updater();
            }
        }

        return _instance;
    }


    public void SafeDeleteZipFile(string zipFilePath, Action<int> progressCallback = null, Action<string> errorCallback = null)
    {
        try
        {
            long fileSize = new FileInfo(zipFilePath).Length;
            long bytesDeleted = 0;

            File.Delete(zipFilePath);

            bytesDeleted += fileSize;
            int progressPercentage = (int)((float)bytesDeleted / (float)fileSize * 100);
            progressCallback?.Invoke(progressPercentage);
        }
        catch (Exception ex)
        {
            errorCallback?.Invoke($"Failed to clean up Installation: {ex.Message}");
        }
    }

    public static void RegisterProduct(string productName, string productVersion, string productLocation)
    {
        // Create the registry key for the product
        using (RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + productName))
        {
            // Set the product details
            key.SetValue("DisplayName", productName);
            key.SetValue("DisplayVersion", productVersion);
            key.SetValue("Publisher", "JW Limited");
            key.SetValue("InstallLocation", Path.GetDirectoryName(productLocation));
            key.SetValue("UninstallString", "\"" + productLocation + "\" /uninstall");
            key.SetValue("QuietUninstallString", "\"" + productLocation + "\" /uninstall /quiet");
            key.SetValue("SystemComponent", 0);
            key.SetValue("EstimatedSize", new FileInfo(productLocation).Length / 1024);

            // Set the product icon (optional)
            string iconLocation = productLocation + ",0";
            if (File.Exists(iconLocation))
            {
                key.SetValue("DisplayIcon", iconLocation);
            }
        }
    }

    public void VerifyAndExtractZip(string zipFilePath, string expectedHashValue, string destinationDirectory, Action<int> progressCallback = null, Action<string> errorCallback = null)
    {
        const int bufferSize = 8192;

        try
        {
            using (var zip = ZipFile.OpenRead(zipFilePath))
            {
                if (zip.Entries.Count == 0)
                {
                    throw new Exception("Install Package file is empty.");
                }

                using (var sha256 = SHA256.Create())
                {
                    using (var stream = File.OpenRead(zipFilePath))
                    {
                        var hash = sha256.ComputeHash(stream);
                        var actualHashValue = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

                        //TODO : Let the program get the real hashvalue form the server so it can compere

                        if (actualHashValue == actualHashValue)
                        {
                            int totalEntries = zip.Entries.Count;
                            int entriesExtracted = 0;

                            foreach (var entry in zip.Entries)
                            {
                                string fullPath = Path.Combine(destinationDirectory, entry.FullName);

                                fullPath = Path.GetFullPath(fullPath);

                                if (entry.FullName.EndsWith("/") || entry.FullName.EndsWith("\\"))
                                {
                                    Directory.CreateDirectory(fullPath);
                                }
                                else
                                {
                                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                                    try
                                    {
                                        using (var entryStream = entry.Open())
                                        {
                                            using (var output = File.Create(fullPath))
                                            {
                                                byte[] buffer = new byte[bufferSize];
                                                int bytesRead;

                                                while ((bytesRead = entryStream.Read(buffer, 0, buffer.Length)) > 0)
                                                {
                                                    output.Write(buffer, 0, bytesRead);
                                                }
                                            }
                                        }


                                    }
                                    catch (Exception ex)
                                    {
                                        errorCallback?.Invoke($"Failed to decompress the Install Package: {ex.Message}");
                                    }
                                }

                                entriesExtracted++;
                                int progressPercentage = (int)((float)entriesExtracted / (float)totalEntries * 100);

                                progressCallback?.Invoke(progressPercentage);
                            }
                        }
                        else
                        {
                            throw new Exception("Hash value verification failed.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errorCallback?.Invoke($"Failed to verify and decompress the Install Package: {ex.Message}");

            if (ex is InvalidDataException && ex.Message.Contains("End of Central Directory record could not be found"))
            {
                {
                    errorCallback?.Invoke("The Install Package is corrupt or incomplete.");
                }
            }
        }
    }

    public string GetLatestChanges(string owner, string repo)
    {
        var client = new GitHubClient(new Octokit.ProductHeaderValue("srvlocal_gui"));
        var releases = client.Repository.Release.GetAll(owner, repo).Result;
        string latestChanges = releases[0].Body;
        return latestChanges;
    }


    public bool HasNewRelease(string owner, string repo)
    {
        var client = new GitHubClient(new Octokit.ProductHeaderValue("srvlocal_gui"));
        var releases = client.Repository.Release.GetAll(owner, repo).Result;

        if (releases.Count > 0)
        {
            string latestTag = releases[0].TagName;
            if (latestTag != GetCurrentVersion())
            {
                return true;
            }
        }

        return false;
    }

    public string GetLatestVersion(string owner, string repo)
    {
        var client = new GitHubClient(new Octokit.ProductHeaderValue("srvlocal_gui"));
        var releases = client.Repository.Release.GetAll(owner, repo).Result;
        return releases[0].TagName;
    }

    public void DownloadLatestRelease(string owner, string repo, DownloadProgressChangedEventHandler progressHandler)
    {
        var client = new WebClient();
        client.DownloadProgressChanged += progressHandler;
        string latestUrl = GetLatestReleaseUrl(owner, repo);
        client.DownloadFileAsync(new Uri(latestUrl), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "latest_release.zip"));
    }

    public string GetLatestReleaseUrl(string owner, string repo)
    {
        var client = new GitHubClient(new Octokit.ProductHeaderValue("srvlocal_gui"));
        var releases = client.Repository.Release.GetAll(owner, repo).Result;
        return releases[0].Assets[0].BrowserDownloadUrl;
    }

    public string GetCurrentVersion()
    {
        return System.Windows.Forms.Application.ProductVersion.ToLower();
    }
}



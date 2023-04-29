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


class GitHubReleaseChecker
{
    private readonly string _owner;
    private readonly string _repo;
    private HttpClient _client;
    private string _accessToken;

    public GitHubReleaseChecker(string owner, string repo, string accessToken)
    {
        _owner = owner;
        _repo = repo;

        _accessToken = accessToken;
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _accessToken);
    }

    public async Task<string> CheckForNewRelease()
    {
        var latestReleaseUrl = $"https://api.github.com/repos/{_owner}/{_repo}/releases/latest";
        var latestReleaseJson = await GetJsonAsync(latestReleaseUrl);
        var latestRelease = JsonConvert.DeserializeObject<Release>(latestReleaseJson);

        var currentReleaseUrl = $"https://api.github.com/repos/{_owner}/{_repo}/releases";
        var currentReleaseJson = await GetJsonAsync(currentReleaseUrl);
        var currentReleases = JsonConvert.DeserializeObject<Release[]>(currentReleaseJson);


        if (latestRelease.Name != currentReleases[0].Name)
        {
            if(MessageBox.Show("A new release is available: " + latestRelease.Name + "\n\nDownalod now?","New Update",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                DownloadRelease(latestRelease);
            }
            return "A new release is available: " + latestRelease.Name;
        }
        else
        {
            return "No new release available.";
        }
    }

    private void DownloadRelease(Release release)
    {
        var downloadUrl = release.Assets[0].BrowserDownloadUrl;
        var client = new WebClient();
        client.DownloadFile(downloadUrl, release.Name + ".zip");
        Process exp = Process.Start("explorer.exe",release.Name + ".zip");
        Console.WriteLine("Download complete.");
    }

    private async Task<string> GetJsonAsync(string url)
    {
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new Exception("Error fetching data from API: " + response.StatusCode);
        }
    }

    private class Release
    {
        public string Name { get; set; }
        public Asset[] Assets { get; set; }
    }

    private class Asset
    {
        public string BrowserDownloadUrl { get; set; }
    }
}


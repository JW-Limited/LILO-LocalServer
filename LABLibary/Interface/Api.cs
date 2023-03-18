using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Diagnostics;
using LILO.UI.Forms;
using SQLitePCL;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Win32;

namespace LILO.Shell;
internal class Api
{
    public class OneDrive
    {
        // Replace these values with your client ID and secret
        private const string clientId = "4cd6feab-236c-479c-bf8c-18e8418bacf7";
        private const string clientSecret = "cef293b6-27f8-4ab0-988a-e83b6cb0227c";

        public static async void DownloadFile(string fileId, string savePath)
        {
            string token = await GetAuthTokenAsync();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://graph.microsoft.com/v1.0/me/drive/items/{fileId}/content");
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer " + token);

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                using (FileStream fileStream = File.Create(savePath))
                {
                    stream.CopyTo(fileStream);
                }
            }
            else
            {
                throw new Exception($"Request returned with status code {response.StatusCode}");
            }
        }

        private static async Task<string> GetAuthTokenAsync()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/common/oauth2/v2.0/token");
            request.Content = new StringContent("client_id=" + clientId + "&client_secret=" + clientSecret + "&grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();

            dynamic responseJson = JsonConvert.DeserializeObject(responseString);
            return responseJson.access_token;
        }
    }


    public class WinRegistry
    {
        public class Keys
        {
            public void SetKeyValue(string keyName, string keyValue)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("LILO", true);

                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey("LILO");
                }

                key.SetValue(keyName, keyValue);
            }

            public string GetKeyValue(string keyName)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("LILO");

                if (key == null)
                {
                    return "Key not found.";
                }

                var value = key.GetValue(keyName) as string;

                if (value == null)
                {
                    return "Value not found.";
                }

                return value;
            }
        }
    }


    public class Youtube
    {

        // Discontinued because of massiv code Changes in Youtubes Api

        /*
        public string _clientId = "YOUR_CLIENT_ID";
        public string _clientSecret = "YOUR_CLIENT_SECRET";
        public string _videoId = "VIDEO_ID";

        public static void Download()
        {
            // Authenticate with YouTube
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = _clientId,
                    ClientSecret = _clientSecret
                },
                new[] { YouTubeService.Scope.Youtube },
                "user",
                CancellationToken.None
            ).Result;

            // Create a new YouTube service
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTubeDownloader"
            });

            // Download the video
            var video = youtubeService.Videos.List("snippet").ExecuteAsync(_videoId).Result;
            if (video.Items.Count > 0)
            {
                var videoSnippet = video.Items[0].Snippet;
                Console.WriteLine($"Downloading video: {videoSnippet.Title}");

                var videoStream = youtubeService.Videos.List("id,contentDetails,fileDetails,liveStreamingDetails,player,processingDetails,recordingDetails,snippet,statistics,status,topicDetails").ExecuteAsync(_videoId).Result;
                if (videoStream.Items.Count > 0)
                {
                    var downloadUrl = videoStream.Items[0].ContentDetails.;
                    using (WebClient client = new WebClient())
                    {
                        // Set the user agent to mimic a web browser
                        client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                        // Download the video and save it to the current directory
                        client.DownloadFile(downloadUrl, "video.mp4");
                    }
                }
            }
        }*/
    }


    public class Deezer
    {
        public void requestSongTitle(string trackid,TextBox box)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "LILO/1.0");

            var response = client.GetAsync($"https://api.deezer.com/track/{trackid}").Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            box.Text = data.title;
        }

        public string SearchSong (string songName,TextBox title)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "LILO/1.0");
            var response = client.GetAsync($"https://api.deezer.com/search/track?q={songName}").Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            title.Text = data.data[0].title;
            return data.data[0].id;
        }

        public void ShowResultsInList(string songName, ListView list)
        {
            string url = $"https://api.deezer.com/search/song?q={songName}";

            WebClient client = new WebClient();

            try
            {
                string response = client.DownloadString(url);

                dynamic json = JObject.Parse(response);

                foreach (var song in json.data)
                {
                    list.Items.Add(song.title);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public string SearchArtistName(string trackID)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "LILO/1.0");
            var response = client.GetAsync($"https://api.deezer.com/track/{trackID}").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            return data.artist.name;
        }

        public void SearchCover(string trackId,string trackName,Panel img)
        {
            if (!Directory.Exists(".\\temp\\covers")) Directory.CreateDirectory(".\\temp\\covers");
            string url = $"https://api.deezer.com/track/{trackId}";

            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString(url);
                dynamic responseData = JsonConvert.DeserializeObject(response);
                string coverUrl = responseData.album.cover_big;

                client.DownloadFile(coverUrl, $".\\temp\\covers\\{trackName}_cover.jpg");
                img.BackgroundImage = new Bitmap($".\\temp\\covers\\{trackName}_cover.jpg");
            }
        }

        public string previewURL(string trackID)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "LILO/1.0");
            var response = client.GetAsync($"https://api.deezer.com/track/{trackID}").Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            return data.preview;
        }

        public void downloadSong(string trackID, string trackName, string artist)
        {
            if (!Directory.Exists(".\\temp\\tracks")) Directory.CreateDirectory(".\\temp\\tracks");
            string url = previewURL(trackID);

            WebClient client = new WebClient();

            try
            {
                client.DownloadFile(url, $".\\temp\\tracks\\{trackName} - {artist}.mp3");

                Player player = new Player($"{AppDomain.CurrentDomain.BaseDirectory}\\temp\\tracks\\{trackName} - {artist}.mp3");
                player.cover = new Bitmap($"{AppDomain.CurrentDomain.BaseDirectory}\\temp\\covers\\{trackName}_cover.jpg");
                player.title = trackName;
                player.artist = artist;
                player.Show();
            }
            catch (WebException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}



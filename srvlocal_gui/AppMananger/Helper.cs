using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace srvlocal_gui.AppMananger
{
    public class Helper
    {
        private static void TrackPerformance(string operation, Action action)
        {
            var stopwatch = Stopwatch.StartNew();

            action();

            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            Logger.Instance.Log($"Operation: {operation}, Elapsed Time: {elapsedMilliseconds}ms", logLevel: Logger.LogLevel.Info);
            Console.WriteLine($"Operation: {operation}, Elapsed Time: {elapsedMilliseconds}ms");
        }


        public class User
        {
            public enum _UserRights
            {
                Admin,
                PowerUser,
                Guest,
                Normal
            }

            public static string CheckUserPermissions()
            {
                WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

                bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

                if (isAdmin)
                {
                    Logger.Instance.Log("You are an administrator.");
                    return "Admin";
                }
                else
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    IdentityReferenceCollection groups = identity.Groups;

                    bool isPowerUser = CheckLocalGroupMembership(groups, "Power Users");
                    bool isGuest = CheckLocalGroupMembership(groups, "Guests");

                    if (isPowerUser)
                    {
                        Logger.Instance.Log("You are a Power User.");
                        return "PowerUser";
                    }
                    else if (isGuest)
                    {
                        Logger.Instance.Log("You are a Guest User.");
                        return "Guest";
                    }
                    else
                    {
                        Logger.Instance.Log("You have a standard user role.");
                        return "Normal";
                    }
                }
            }

            private static bool CheckLocalGroupMembership(IdentityReferenceCollection groups, string groupName)
            {
                foreach (IdentityReference group in groups)
                {
                    try
                    {
                        IntPtr token = WindowsIdentity.GetCurrent().Token;
                        WindowsIdentity identity = new WindowsIdentity(token);
                        WindowsPrincipal principal = new WindowsPrincipal(identity);

                        if (principal.IsInRole(groupName))
                        {
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Log(ex.Message, Logger.LogLevel.Error);
                    }
                }

                return false;
            }
        }

        public static async Task<bool> VerifyEmailAsync(string email)
        {
            const string apiKey = "YOUR_RAPIDAPI_KEY_HERE";
            const string apiUrl = "https://email-verifier1.p.rapidapi.com/v1/";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["email"] = email;

            var url = $"{apiUrl}verify?{query}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<EmailVerificationResult>(json);
                return result.Status == "valid";
            }
            else
            {
                throw new Exception($"Failed to verify email address: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }

        public static async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            // Set up the request URL and parameters
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
                {
                    { "X-RapidAPI-Key", "7facbca935msh0800aea598dca8ap19cf02jsn17a04c128f7c" },
                    { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "q", text },
                    { "target", "de" },
                    { "source", "en" },
                }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(json);
                    string translation = result.data.translations[0].translatedText;

                    return translation;
                }
                else
                {
                    return "Failed to translate text";
                }

            }

        }
        private static string BuildQueryString(Dictionary<string, string> parameters)
        {
            var queryParameters = new List<string>();
            foreach (var kvp in parameters)
            {
                queryParameters.Add($"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}");
            }
            return string.Join("&", queryParameters);
        }

        public static async Task<string> GetQuoteOfTheDayAsync()
        {
            // Create an HttpClient with the required headers
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "quotes15.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "7facbca935msh0800aea598dca8ap19cf02jsn17a04c128f7c");

            // Make a GET request to the Quotes Free API
            HttpResponseMessage response = await client.GetAsync("https://quotes15.p.rapidapi.com/quotes/random/");
            if (response.IsSuccessStatusCode)
            {
                // Parse the JSON response and extract the quote of the day
                string json = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(json);
                string quote = result.content;
                string author = result.originator.name;

                // Return the quote of the day
                return $"{quote} - {author}";
            }
            else
            {
                // Return an error message if the request failed
                return "Failed to get quote of the day";
            }
        }
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute hash from the input string
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }

    public class EmailVerificationResult
    {
        public string Email { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public string Role { get; set; }
        public string Disposable { get; set; }
        public string Free { get; set; }
        public string AcceptAll { get; set; }
        public string VerifiedAt { get; set; }
        public string Source { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
    }

}

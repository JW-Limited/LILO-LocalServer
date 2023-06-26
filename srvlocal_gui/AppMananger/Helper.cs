using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace srvlocal_gui.AppMananger
{
    public class Helper
    {
        public static bool IsValidEmail(string email)
            {
                // The regular expression to check for a valid email address.
                const string emailRegex =
                    @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,})$";

                // Create a Regex object to use to validate the email address.
                Regex regex = new Regex(emailRegex);

                // Check if the email address matches the regular expression.
                return regex.IsMatch(email);
            }

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

        public static bool IsInEmailFormat(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                if (email.Contains("@") && email.Contains("."))
                {
                    return true;
                }
            }

            return false;
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
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "quotes15.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "7facbca935msh0800aea598dca8ap19cf02jsn17a04c128f7c");

            HttpResponseMessage response = await client.GetAsync("https://quotes15.p.rapidapi.com/quotes/random/");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(json);
                string quote = result.content;
                string author = result.originator.name;

                return $"{quote} - {author}";
            }
            else
            {
                return "Failed to get quote of the day";
            }
        }
        public static string ComputeHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }

}

/*

        Copyright© 2023 Joe Valentino Lengefeld

        Licensed under the Apache License, Version 2.0 (the "License");
        you may not use this file except in compliance with the License.
        You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
        Unless required by applicable law or agreed to in writing, software
        distributed under the License is distributed on an "AS IS" BASIS,
        WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
        See the License for the specific language governing permissions and
        limitations under the License.

        Last edit : 02.04.2023
*/


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LABLibary.Converter
{
    public class StringC
    {
        public static int AppLine = 0;

        public static string StrArrayToString(string[] str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str2 in str)
            {
                if (str2 != string.Empty && str2 != "" && str2 != " ") sb.AppendLine(str2);
                else { continue ; }
            }
            return sb.ToString();
        }

        public static string StrArrayToNumString(string[] str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string sb1 in str)
            {
                if (sb1 == string.Empty || sb1 == "" || sb1 == " ") continue;
                else if (sb1 != "")
                {
                    AppLine++;
                    sb.AppendLine(AppLine + " : " + sb1);
                }
            }

            return sb.ToString();
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        public static byte[] ConvertToByteArray(string nonBase64String)
        {
            // Convert the non-Base64 string to bytes
            byte[] bytes = Encoding.UTF8.GetBytes(nonBase64String);

            // Convert the bytes to a Base64 encoded string
            string base64String = Convert.ToBase64String(bytes);

            // Convert the Base64 encoded string to a byte array
            byte[] byteArray = Convert.FromBase64String(base64String);

            return byteArray;
        }


    }

    public static class TemperatureConverter
    {
        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }

    public class DateTimeC
    {
        public static string DateTimeToString(DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        public static DateTime StringToDateTime(string str, string format)
        {
            return DateTime.ParseExact(str, format, null);
        }

        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (long)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static DateTime UnixTimestampToDateTime(long unixTimestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
        }
    }

    public class ListC
    {
        public static string ListToString(List<string> list)
        {
            if(list.Count <= 1)
            {
                return "none";
            }
            StringBuilder sb = new StringBuilder();
            foreach (string item in list)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }
    }

    public class ByteC
    {
        public static byte[] StringToByteArray(string str)
        {
            return System.Text.Encoding.UTF8.GetBytes(str);
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static int ByteArrayToInt(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }

        public static byte[] IntToByteArray(int value)
        {
            return BitConverter.GetBytes(value);
        }

        
    }
    public class EnumC
    {
        public static T StringToEnum<T>(string str)
        {
            return (T)Enum.Parse(typeof(T), str, true);
        }

        public static string EnumToString(Enum e)
        {
            return e.ToString();
        }

        public static bool IsValidEnumValue<T>(string str)
        {
            return Enum.IsDefined(typeof(T), str);
        }
    }

    public class PathC
    {
        public static string UnixPathToWindowsPath(string unixPath)
        {
            return unixPath.Replace('/', '\\');
        }

        public static string WindowsPathToUnixPath(string windowsPath)
        {
            return windowsPath.Replace('\\', '/');
        }
    }

    public class ColorC
    {
        public static string ColorToHex(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        public static Color HexToColor(string hex)
        {
            hex = hex.Replace("#", "");
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);
            return Color.FromArgb(r, g, b);
        }

        public static string ColorToRgbString(Color color)
        {
            return string.Format("rgb({0},{1},{2})", color.R, color.G, color.B);
        }
    }
    public class IPAddressC
    {
        public static IPAddress Parse(string ipAddressString)
        {
            if (IPAddress.TryParse(ipAddressString, out IPAddress ipAddress))
            {
                return ipAddress;
            }
            else
            {
                throw new ArgumentException("Invalid IP address string.");
            }
        }

        public static bool IsInRange(IPAddress ipAddress, IPAddress startIpAddress, IPAddress endIpAddress)
        {
            if (ipAddress.AddressFamily != startIpAddress.AddressFamily || ipAddress.AddressFamily != endIpAddress.AddressFamily)
            {
                throw new ArgumentException("IP address range is not valid.");
            }

            byte[] ipAddressBytes = ipAddress.GetAddressBytes();
            byte[] startIpAddressBytes = startIpAddress.GetAddressBytes();
            byte[] endIpAddressBytes = endIpAddress.GetAddressBytes();

            bool isInRange = true;
            for (int i = 0; i < ipAddressBytes.Length; i++)
            {
                if (ipAddressBytes[i] < startIpAddressBytes[i] || ipAddressBytes[i] > endIpAddressBytes[i])
                {
                    isInRange = false;
                    break;
                }
            }

            return isInRange;
        }
    }

    public class TimeZoneC
    {
        public static DateTime ConvertToTimeZone(DateTime utcTime, string timeZoneId)
        {
            try
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZone);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException("Invalid time zone ID.");
            }
        }

        public static string GetCurrentTimeZoneId()
        {
            return TimeZoneInfo.Local.Id;
        }
    }

    public class CurrencyC
    {
        public static string CurrencyCodeToSymbol(string code)
        {
            try
            {
                return new RegionInfo(code).CurrencySymbol;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid currency code.");
            }
        }

        public static string CurrencySymbolToCode(string symbol)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.Name);
                if (region.CurrencySymbol == symbol)
                {
                    return region.ISOCurrencySymbol;
                }
            }
            throw new ArgumentException("Invalid currency symbol.");
        }
    }
    public class URLC
    {
        public static (string protocol, string domain, string path, string queryString) ParseURL(string url)
        {
            var uri = new Uri(url);
            var protocol = uri.Scheme;
            var domain = uri.Host;
            var path = uri.AbsolutePath;
            var queryString = uri.Query;

            return (protocol, domain, path, queryString);
        }
    }

    public class FileC
    {
        public static string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File {filePath} not found.");
            }

            using var reader = new StreamReader(filePath);
            return reader.ReadToEnd();
        }

        public static void WriteFile(string filePath, string content)
        {
            if(!File.Exists(filePath)) { File.Create(filePath); }

            var commands = new Dictionary<string, string>();
            var configFile = File.ReadAllLines(filePath);
            foreach (var line in configFile)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    commands[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }

        public static bool CheckPermissions(string filePath, FileAccess access)
        {
            try
            {
                using var stream = new FileStream(filePath, FileMode.Open, access);
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }

            return true;
        }

        public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public static string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }
    }

    public class MathC
    {
        public static int Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Input must be a non-negative integer.");

            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        public static double SolveEquation(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("Input must have a non-zero coefficient for x^2.");

            double delta = b * b - 4 * a * c;
            if (delta < 0)
                throw new ArgumentException("Input must have real roots.");

            return (-b + Math.Sqrt(delta)) / (2 * a);
        }
    }

    public class StringCaseC
    {
        public static string ToCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string[] words = input.Split(' ', '-', '_');
            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result += textInfo.ToTitleCase(words[i].ToLower());
            }
            return result;
        }

        public static string ToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string[] words = input.Split(' ', '-', '_');
            string result = "";
            for (int i = 0; i < words.Length; i++)
            {
                result += textInfo.ToTitleCase(words[i].ToLower());
            }
            return result;
        }

        public static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] words = input.Split(' ', '-', '_');
            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result += "_" + words[i].ToLower();
            }
            return result;
        }

        public static string ToKebabCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] words = input.Split(' ', '-', '_');
            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result += "-" + words[i].ToLower();
            }
            return result;
        }
    }
    public class NetworkC
    {
        public static bool PingHost(string hostNameOrAddress)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but you can set a different value if needed.
            options.Ttl = 128;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Wait 5 seconds for a reply.
            int timeout = 5000;

            try
            {
                PingReply reply = pingSender.Send(hostNameOrAddress, timeout, buffer, options);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetLocalIPAddress()
        {
            // Get the IP address of the first network interface that is up and running.
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    IPInterfaceProperties ipProps = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(addr.Address))
                        {
                            return addr.Address.ToString();
                        }
                    }
                }
            }

            // If no suitable IP address is found, return a loopback address.
            return IPAddress.Loopback.ToString();
        }

        public static string SendHttpRequest(string url)
        {
            WebClient client = new WebClient();
            string result = "";

            try
            {
                result = client.DownloadString(url);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}


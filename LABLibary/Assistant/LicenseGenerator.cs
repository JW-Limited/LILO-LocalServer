using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LABLibary.Assistant
{
    public class LicenseGenerator
    {
        private const int CODE_LENGTH = 16;
        private const int KEY_LENGTH = 32;
        private const string CODE_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public class DecodeProcessInformation
        {
            public bool SuccessFull { get; set; }
            public string ErrorMessage { get; set; }
            public string Message { get; set; }
            public string Info { get; set; }
        }

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
        {
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            string plaintext = null;

            // Create an Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static string GenerateCode(string productName, string productVersion, DateTime expirationDate)
        {
            // generate a random encryption key
            byte[] key = new byte[KEY_LENGTH];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
                LicenseValues.Default.key = LABLibary.Converter.StringC.ByteArrayToString(key);
            }

            // generate a random initialization vector
            byte[] iv = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
                LicenseValues.Default.iv = LABLibary.Converter.StringC.ByteArrayToString(iv);
            }

            // create a plaintext license string
            string licenseText = $"{productName}|{productVersion}|{expirationDate.ToString("yyyy-MM-dd")}";
            LicenseValues.Default.licCode = licenseText;

            LicenseValues.Default.Save();

            // encrypt the license string using AES-256 CBC mode
            byte[] encrypted = EncryptStringToBytes_Aes(licenseText, key, iv);

            // generate a random string of characters to use as the code
            char[] code = new char[CODE_LENGTH];
            RandomNumberGenerator rngCode = RandomNumberGenerator.Create();
            byte[] codeBytes = new byte[CODE_LENGTH];
            rngCode.GetBytes(codeBytes);

            for (int i = 0; i < CODE_LENGTH; i++)
            {
                code[i] = CODE_CHARS[codeBytes[i] % CODE_CHARS.Length];
            }

            // combine the encryption key, initialization vector, and encrypted license string into a single byte array
            byte[] data = new byte[KEY_LENGTH + 16 + encrypted.Length];
            Buffer.BlockCopy(key, 0, data, 0, KEY_LENGTH);
            Buffer.BlockCopy(iv, 0, data, KEY_LENGTH, 16);
            Buffer.BlockCopy(encrypted, 0, data, KEY_LENGTH + 16, encrypted.Length);

            // convert the combined data to a base64-encoded string
            string base64 = Convert.ToBase64String(data);

            // remove any padding characters ('=')
            base64 = base64.TrimEnd('=');

            // insert dashes into the code for readability
            for (int i = 4; i < CODE_LENGTH; i += 5)
            {
                code[i] = '-';
            }

            // insert the base64-encoded data into the code
            int base64Index = 0;
            for (int i = 0; i < base64.Length; i++)
            {
                if (base64[i] == '=')
                {
                    // Skip padding characters
                    continue;
                }

                int index = (i * 2) % (CODE_LENGTH - 4) + 4;
                code[index] = base64[i];
                base64Index++;
            }

            // return the generated code as a string
            return new string(code);
        }

        public static (bool IsValid, string ErrorMessage) IsValidBase64(string base64)
        {
            if (base64.Length % 4 != 0)
            {
                return (false, "Length must be a multiple of 4");
            }

            if (base64.Contains(" ") || base64.Contains("\t") ||
                base64.Contains("\r") || base64.Contains("\n"))
            {
                return (false, "Contains invalid whitespace characters");
            }

            if (base64[base64.Length - 1] == '=')
            {
                if (!base64.EndsWith("=="))
                {
                    return (false, "Invalid padding");
                }
            }
            else if (base64[base64.Length - 2] == '=')
            {
                if (!base64.EndsWith("="))
                {
                    return (false, "Invalid padding");
                }
            }

            foreach (char c in base64)
            {
                if (!IsBase64Char(c))
                {
                    return (false, "Contains invalid base64 character");
                }
            }

            return (true, "");
        }

        private static bool IsBase64Char(char c)
        {
            return (c >= 'A' && c <= 'Z') ||
                   (c >= 'a' && c <= 'z') ||
                   (c >= '0' && c <= '9') ||
                   c == '+' || c == '/' || c == '=';
        }

        public static DecodeProcessInformation DecodeLicense(string licenseCode, out string productName, out string productVersion, out DateTime expirationDate)
        {
            var returnInfo = new DecodeProcessInformation();
            returnInfo.SuccessFull = true;

            string base64 = licenseCode.Replace("-", "");

            var (isValid, errorMessage) = IsValidBase64(base64);


            if (!isValid)
            {
                returnInfo.ErrorMessage = "Invalid base64 license code - IsValidMetod\n\n" + errorMessage + base64;
                returnInfo.SuccessFull = false;
                productName = null;
                productVersion = null;
                expirationDate = default;
                return returnInfo;
            }

            byte[] data = null;
            try
            {
                data = Convert.FromBase64String(base64);

                //data = LABLibary.Converter.StringC.ConvertToByteArray(licenseCode);

                byte[] key = new byte[KEY_LENGTH];
                byte[] iv = new byte[16];
                Buffer.BlockCopy(data, 0, key, 0, KEY_LENGTH);
                Buffer.BlockCopy(data, KEY_LENGTH, iv, 0, 16);

                // extract the encrypted license string from the data
                byte[] encrypted = new byte[data.Length - KEY_LENGTH - 16];
                Buffer.BlockCopy(data, KEY_LENGTH + 16, encrypted, 0, encrypted.Length);

                string licenseText = null;

                try
                {
                    key = LABLibary.Converter.ByteC.StringToByteArray(LicenseValues.Default.key);
                    iv = LABLibary.Converter.ByteC.StringToByteArray(LicenseValues.Default.iv);
                    licenseText = DecryptStringFromBytes_Aes(encrypted, key, iv);
                    //licenseText = LicenseValues.Default.licCode;
                }
                catch (CryptographicException ce)
                {
                    productName = null;
                    productVersion = null;
                    expirationDate = default(DateTime);

                    returnInfo.ErrorMessage += ce.Message + "\n\nCrypthograpy Problem";
                    returnInfo.SuccessFull = false;
                }

                // extract the product name, version, and expiration date from the license string
                string[] parts = licenseText.Split('|');
                if (parts.Length != 3 || string.IsNullOrEmpty(parts[0]) || string.IsNullOrEmpty(parts[1]))
                {
                    productName = null;
                    productVersion = null;
                    expirationDate = default(DateTime);

                    returnInfo.ErrorMessage += "\nLicenseparts missing.";
                    returnInfo.SuccessFull = false;
                }

                productName = parts[0];
                productVersion = parts[1];
                if (!DateTime.TryParseExact(parts[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out expirationDate))
                {
                    productName = null;
                    productVersion = null;
                    expirationDate = default(DateTime);

                    returnInfo.ErrorMessage += "\nDate parsing Error";
                    returnInfo.SuccessFull = false;
                }

                // check if the license has expired
                if (expirationDate < DateTime.Today)
                {
                    productName = null;
                    productVersion = null;
                    expirationDate = default(DateTime);

                    returnInfo.Message += "\nLicense Expired.";
                    returnInfo.SuccessFull = false;
                }

                return returnInfo;
            }
            catch (FormatException)
            {
                returnInfo.ErrorMessage = "Invalid base64 license code - Exception";
                returnInfo.SuccessFull = false;
                // Set outputs to null
                productName = null;
                productVersion = null;
                expirationDate = default;
                return returnInfo;
            }
            catch (Exception ce)
            {
                productName = null;
                productVersion = null;
                expirationDate = default(DateTime);

                returnInfo.ErrorMessage += ce.Message + base64;
                returnInfo.SuccessFull = false;
                return returnInfo;
            }

        }

    }
}

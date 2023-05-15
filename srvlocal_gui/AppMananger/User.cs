using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    public class User
    {
        public User()
        {
            // Parameterless constructor required for deserialization
        }

        private bool _isActivated;
        private string _userName;
        private string _hashedPassword;
        private bool _canChangeConfig;
        private string _LastLogin;
        private string _email;

        public string LastLogin
        {
            get => _LastLogin;
            set
            {
                if (value != null && !_canChangeConfig)
                {
                    throw new ArgumentException("Cannot change config");
                }
                _LastLogin = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or empty");
                }
                _email = value;
            }
        }

        public bool IsActivated
        {
            get => _isActivated;
            set
            {
                if (value == false && _canChangeConfig)
                {
                    throw new ArgumentException("Cannot deactivate user with permission to change config");
                }
                _isActivated = value;
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty");
                }
                _userName = value;
            }
        }

        public string HashedPassword
        {
            get => _hashedPassword;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password cannot be null or empty");
                }
                _hashedPassword = ComputeHash(value);
            }
        }

        public bool CanChangeConfig
        {
            get => _canChangeConfig;
            set
            {
                if (value == true && !_isActivated)
                {
                    throw new ArgumentException("Cannot grant permission to inactive user");
                }
                _canChangeConfig = value;
            }
        }


        public User(string username, string password)
        {
            IsActivated = true;
            UserName = username;
            HashedPassword = ComputeHash(password);
            CanChangeConfig = true;
            LastLogin = null;
        }

        public static bool IsSHA256Hash(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            if (str.Length != 64)
            {
                return false;
            }

            // Use regular expression to check if the string only contains hexadecimal characters
            if (!Regex.IsMatch(str, "^[0-9a-fA-F]+$"))
            {
                return false;
            }

            // Attempt to convert the string to a byte array
            byte[] hashBytes;
            try
            {
                hashBytes = StringToByteArray(str);
            }
            catch (FormatException)
            {
                return false;
            }

            // Verify that the byte array has a length of 32 (i.e. 256 bits)
            if (hashBytes.Length != 32)
            {
                return false;
            }

            return true;
        }

        private static byte[] StringToByteArray(string str)
        {
            int numChars = str.Length;
            byte[] bytes = new byte[numChars / 2];

            for (int i = 0; i < numChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
            }

            return bytes;
        }

        public static string ComputeHash(string input)
        {

            Logger.Instance.Log(input);

            if (!IsSHA256Hash(input))
            {

                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    Logger.Instance.Log(input + " - " + builder.ToString());

                    return builder.ToString();
                }
            }
            else
            {
                Logger.Instance.Log($"String \"{input}\" is already hashed.");

                return input;
            }

        }
    }
}

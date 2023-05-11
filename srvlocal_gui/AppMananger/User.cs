using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                _hashedPassword = HashPassword(value);
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
            _hashedPassword = HashPassword(password);
            _canChangeConfig = true;
        }

        public bool CheckPassword(string password)
        {
            return _hashedPassword == HashPassword(password);
        }

        private static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            byte[] hash = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);
            return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
        }
    }
}

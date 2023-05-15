using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    public class UserManager
    {
        private readonly string _filePath =".\\settings.json";
        private readonly object _lock = new object();
        public static object padlock = new object();
        private readonly List<User> _users = new List<User>();

        private static UserManager instance = null;

        public static UserManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserManager();
                    }
                    return instance;
                }
            }
        }


        private UserManager()
        {
            _users = LoadUsersFromFile();
        }

        public List<User> GetUsers()
        {
            return _users.ToList(); 
        }

        public void AddUser(User user)
        {
            lock (_lock)
            {
                if (_users.Any(u => u.UserName == user.UserName))
                {
                    throw new ArgumentException($"User with name '{user.UserName}' already exists");
                }
                _users.Add(user);
                SaveUsersToFile();
            }
        }
            

        public void RemoveUser(User user)
        {
            lock (_lock)
            {
                _users.Remove(user);
                SaveUsersToFile();
            }
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.UserName == username);
            if (user == null) //!user.CheckPassword(password)
            {
                return null;
            }
            user.LastLogin = DateTime.UtcNow.ToString("o");
            SaveUsersToFile();
            return user;
        }

        public bool UserExists(string username)
        {
            lock (_lock)
            {
                return _users.Exists(u => u.UserName == username);
            }
        }

        private List<User> LoadUsersFromFile()
        {
            try
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<User>>(json);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load users from file '{_filePath}'", ex);
            }
        }

        private void SaveUsersToFile()
        {
            lock (_lock)
            {
                try
                {
                    var json = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(_filePath, json);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Failed to save users to file '{_filePath}'", ex);
                }
            }
        }
    }
}

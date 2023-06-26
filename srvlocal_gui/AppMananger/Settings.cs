using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    public class Settings
    {
        #region TODO : Smarter Version Currently working

        private readonly ConcurrentDictionary<string, object> _settings = new ConcurrentDictionary<string, object>();
        public string WindowTitle
        {
            get => Get<string>(nameof(WindowTitle));
            set => Set(nameof(WindowTitle), value);
        }

        public int ProductVersion
        {
            get => Get<int>(nameof(ProductVersion));
            set => Set(nameof(ProductVersion), value);
        }

        public bool InstalledCorrectly
        {
            get => Get<bool>(nameof(InstalledCorrectly));
            set => Set(nameof(InstalledCorrectly), value);
        }

        public bool CustomPortConfig
        {
            get => Get<bool>(nameof(CustomPortConfig));
            set => Set(nameof(CustomPortConfig), value);
        }

        public bool CustomCDNConfig
        {
            get => Get<bool>(nameof(CustomCDNConfig));
            set => Set(nameof(CustomCDNConfig), value);
        }

        public int Port
        {
            get => Get<int>(nameof(Port));
            set => Set(nameof(Port), value);
        }

        public string CDNPath
        {
            get => Get<string>(nameof(CDNPath));
            set => Set(nameof(CDNPath), value);
        }

        public List<User> Users
        {
            get => Get<List<User>>(nameof(Users));
            set => Set(nameof(Users), value);
        }

        

        private T Get<T>(string key)
        {
            return _settings.TryGetValue(key, out object value) ? (T)value : default(T);
        }

        private void Set<T>(string key, T value)
        {
            _settings[key] = value;
        }
        public void RemoveSetting(string key)
        {
            _settings.TryRemove(key, out _);
        }


        #endregion


    }
}

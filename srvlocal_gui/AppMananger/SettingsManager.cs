using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    public sealed class SettingsManager
    {
        #region Variables

        private static SettingsManager instance = null;
        private static readonly object padlock = new object();

        public static SettingsManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SettingsManager();
                    }
                    return instance;
                }
            }
        }

        private const string SettingsFileName = "settings.json";

        private Settings _settings;

        #endregion

        private SettingsManager()
        {
            _settings = LoadSettings();
        }

        public T GetSetting<T>(Func<Settings, T> settingSelector, T defaultValue = default)
        {
            _settings = LoadSettings();

            T value = settingSelector(_settings);
            if (value != null)
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

        public void SetSetting<T>(Action<Settings, T> settingSelector, T value)
        {
            settingSelector(_settings, value);
            SaveSettings();
        }

        public void RemoveSetting(Func<Settings, object> settingSelector)
        {
            var key = settingSelector.Method.Name;
            _settings.RemoveSetting(key);
            SaveSettings();
        }

        public void ClearSettings()
        {
            _settings = new Settings();
            SaveSettings();
        }

        public void UpdateSettings(Settings settings)
        {
            if (settings != null)
            {
                foreach (PropertyInfo property in typeof(Settings).GetProperties())
                {
                    object value = property.GetValue(settings);
                    if (value != null)
                    {
                        property.SetValue(_settings, value);
                    }
                }

                SaveSettings();
            }
        }

        public Settings LoadSettings()
        {
            if (File.Exists(SettingsFileName))
            {
                //Logger.Instance.Log("Try to load SettingsFile");

                try
                {
                    string json = File.ReadAllText(SettingsFileName);
                    //Logger.Instance.Log($"{json}");
                    var set =  JsonSerializer.Deserialize<Settings>(json);
                    //Logger.Instance.Log(set.CDNPath);
                    return set;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading settings file: {ex.Message}");
                }
            }

            return new Settings();
        }

        public async Task<Settings> LoadSettingsAsync()
        {
            if (File.Exists(SettingsFileName))
            {
                try
                {
                    string encryptedJson = await File.ReadAllTextAsync(SettingsFileName);
                    return JsonSerializer.Deserialize<Settings>(encryptedJson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading settings file: {ex.Message}");
                }
            }

            return new Settings();
        }

        private void SaveSettings()
        {
            try
            {
                string json = JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsFileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings file: {ex.Message}");
            }
        }
    


    }

}

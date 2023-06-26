using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui.AppMananger
{
    public partial class AddUser : Form
    {
        private static AddUser _instance;
        public static object _lock = new object();
        public User LoggedInUser;

        public static AddUser Instance(User user)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AddUser(user);
                }

                return _instance;
            }
        }

        private AddUser(User loggedIn)
        {
            InitializeComponent();

            this.FormClosing += (sender, a) =>
            {
                _instance = null;
            };

            colorComboBox.SelectedValueChanged += (sender, args) =>
            {
                try
                {
                    colorPreviewPanel.FillColor = ParseColor(colorComboBox.Text);
                }
                catch (Exception ex)
                {
                    colorComboBox.Text = "Azure";
                    MessageBox.Show(ex.Message, "Error");
                }
            };

            LoggedInUser = loggedIn;
        }


        private void metroSetDivider1_Click(object sender, EventArgs e)
        {

        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            foreach (var color in ListAllColors())
            {
                colorComboBox.Items.Add(color.Name);
            }
        }

        public List<Color> ListAllColors()
        {
            List<Color> colorList = new List<Color>();

            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                Color color = Color.FromKnownColor(knownColor);
                if (!color.IsSystemColor)
                {
                    colorList.Add(color);
                }
            }

            return colorList;
        }

        public static Color ParseColor(string colorText)
        {
            Color color;
            if (colorText.StartsWith("#") && colorText.Length == 7)
            {
                if (int.TryParse(colorText.Substring(1), System.Globalization.NumberStyles.HexNumber, null, out int colorValue))
                {
                    color = Color.FromArgb(colorValue);
                    return color;
                }
            }
            else
            {
                if (Color.FromName(colorText).IsKnownColor)
                {
                    return Color.FromName(colorText);
                }
            }

            throw new ArgumentException("Invalid color format.");
        }

        private async Task<(bool, string)> AddUserToSettings()
        {
            try
            {
                var user = new User(txtUser.Texts, txtPassword.Texts)
                {
                    Email = txtEmail.Texts,
                    IsActivated = true,
                    FavouriteColor = ParseColor(colorComboBox.Text)
                };


                var settings = SettingsManager.Instance.LoadSettings();
                var users = settings.Users;

                users.Add(user);

                try
                {
                    adminPopup.Target = "https://github.com/JW-Limited/LILO-LocalServer";
                    adminPopup.WindowTitle = "Access Controller";
                    adminPopup.ShowUIForSavedCredentials = true;
                    adminPopup.ShowSaveCheckBox = true;
                    adminPopup.ShowDialog();

                    adminPopup.ShowDialog();

                    if (Helper.ComputeHash(adminPopup.Password) == LoggedInUser.HashedPassword && adminPopup.UserName == LoggedInUser.UserName)
                    {
                        SettingsManager.Instance.SetSetting((s, v) => s.Users = v, users);

                        Form1.Instance.RefreshUserList();
                        Form1.Instance.RefreshUserGreeting(user);

                        return (true, null);
                    }
                    else
                    {
                        return (false, "The Windows API returned an 'AuthorizationFailureCode'.\n\nPlease provide the correct key and username to authorize your action.\n\nIf you believe you are right, contact support.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Log(ex.Message + ex.Source + ex.StackTrace, Logger.LogLevel.Error);

                    return (false, ex.Message);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }


        private async void saaButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

            try
            {
                (var operationSucces, string ErrorCode) = await AddUserToSettings();

                if (!operationSucces)
                {
                    Logger.Instance.Log(ErrorCode, Logger.LogLevel.Error);
                    MessageBox.Show(ErrorCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    panel1.Visible = false;
                }

                else
                {
                    Thread.Sleep(600);

                    panel1.Visible = false;

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex.Message, Logger.LogLevel.Error);
            }


        }
    }
}

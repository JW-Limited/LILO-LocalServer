using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit.Sdk;

namespace srvlocal_gui.AppMananger
{
    public partial class ChangePassword : Form
    {
        public User user;
        private static ChangePassword _instance;
        private static object _instanceLock = new object();
        private static bool isChangingPassword;
        private static bool isChangedPassword;
        public static ChangePassword Instance(User user)
        {
            lock (_instanceLock)
            {
                if (_instance is null)
                {
                    _instance = new ChangePassword(user);
                }

                return _instance;
            }
        }

        private ChangePassword(User userLogged)
        {
            user = userLogged;
            InitializeComponent();

            this.FormClosing += (sender, a) =>
            {
                _instance = null;
            };
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            if (user.HashedPassword == User.ComputeHash("none"))
            {
                pnlOld.Enabled = false;
                txtOldPassword.Enabled = false;
                this.Text = "New Password : " + user.UserName;
            }
            else
            {
                this.Text = "Change Password : " + user.UserName;
            }
        }

        private async void bntChangePassword_Click(object sender, EventArgs e)
        {
            isChangingPassword = true;

            try
            {
                await ChangePasswordAsync();
                isChangedPassword = true;
                isChangingPassword = false;

                Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("All fields need to be filled.\n\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isChangingPassword = false;
            }
            catch (NotEqualException ex)
            {
                MessageBox.Show("The passwords do not match.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isChangingPassword = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isChangingPassword = false;
            }
        }

        private Task ChangePasswordAsync()
        {
            if (Helper.ComputeHash(txtOldPassword.Texts) != user.HashedPassword)
            {
                throw new UnauthorizedAccessException("Wrong Password");
            }

            if (txtNewPassword.Texts != txtNewPasswordRepeat.Texts)
            {
                throw new NotEqualException(txtNewPassword.Texts, txtNewPasswordRepeat.Texts);
            }

            if (txtNewPassword.Texts is null or "" || txtNewPasswordRepeat.Texts is null or "" || txtOldPassword.Texts is null or "")
            {
                throw new ArgumentNullException(nameof(txtNewPassword.Texts));
            }

            var settings = SettingsManager.Instance.LoadSettings();

            foreach (var selecteduser in settings.Users)
            {
                if (selecteduser.UserName == user.UserName)
                {
                    selecteduser.HashedPassword = Helper.ComputeHash(txtNewPassword.Texts);
                }
                else
                {
                    Logger.Instance.Log(selecteduser.UserName + user.UserName);
                }
            }

            SettingsManager.Instance.SetSetting((s, v) => s.Users = v, settings.Users);

            return Task.CompletedTask;
        }

        private void txtNewPassword__TextChanged(object sender, EventArgs e)
        {
            if (txtNewPassword.Texts != txtNewPasswordRepeat.Texts)
            {
                txtNewPasswordRepeat.BorderColor = Color.Red;
                lblDontMatch.Visible = true;
            }
            else
            {
                txtNewPasswordRepeat.BorderColor = Color.Green;
                lblDontMatch.Visible = false;
            }
        }

        private void ChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChangingPassword)
            {
                e.Cancel = true;
            }

            if (isChangedPassword)
            {
                MessageBox.Show("Succesfully changed Password. \n\nThe application is now restarting to garanty youre changes take effect.", "Settings Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Program.SaveRestart();
            }
        }
    }
}

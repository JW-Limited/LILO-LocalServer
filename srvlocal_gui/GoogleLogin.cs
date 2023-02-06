using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Gmail.v1;
using Timer = System.Windows.Forms.Timer;

namespace srvlocal_gui
{
    public partial class GoogleLogin : Form
    {
        public GoogleLogin()
        {
            InitializeComponent();
        }

        public bool LoggedIn;

        private void GoogleLogin_Load(object sender, EventArgs e)
        {
            loading.BringToFront();
            var timer = new Timer() { Interval = 1500 , Enabled = true};
            timer.Tick += (sender, e) => mainView.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string clientId = "YOUR_CLIENT_ID";
            string clientSecret = "YOUR_CLIENT_SECRET";
            string redirectUri = "YOUR_REDIRECT_URI";
            string[] scopes = new string[] { GmailService.Scope.GmailReadonly };
            string email = txtUsername.Text;
            string password = txtPassword.Text;

            LoggedIn = Login(email, password, clientId, clientSecret, redirectUri, scopes);
        }

        public static bool Login(string email, string password, string clientId, string clientSecret, string redirectUri, string[] scopes)
        {
            UserCredential credential;
            try
            {
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        scopes,
                        email,
                        new CancellationToken()
                    ).Result;
                }

                var service = new GmailService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Gmail API Example"
                });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

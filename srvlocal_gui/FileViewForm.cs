using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srvlocal_gui
{
    public partial class FileViewForm : Form
    {
        private static FileViewForm _instance;
        private static object _instanceLock = new object();
        private string? sourceURL;

        public static FileViewForm Instance(string source)
        {
            {
                if (_instance == null)
                {
                    _instance = new FileViewForm(source);
                }

                return _instance;
            }
        }

        private FileViewForm(string source)
        {
            InitializeComponent();
            if (source is not null)
            {
                sourceURL = source;
            }


        }

        private void FileViewForm_Load(object sender, EventArgs e)
        {
            FileView.Source = new Uri(sourceURL);

            FileView.CreateControl();
            FileView.CreateGraphics();


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            var core = FileView.CoreWebView2;

            var settings = core.Settings;

            settings.AreDevToolsEnabled = false;
            settings.IsPinchZoomEnabled = false;
            settings.IsStatusBarEnabled = false;
            settings.IsWebMessageEnabled = false;
            settings.IsZoomControlEnabled = false;
        }
    }
}

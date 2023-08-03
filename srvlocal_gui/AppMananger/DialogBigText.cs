using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

namespace srvlocal_gui.AppMananger
{
    public partial class DialogBigText : Form
    {

        private static DialogBigText _instance;
        private static object _instanceLock = new object();
        private Action<DialogResult> MainAction;
        private bool _isActed = false;

        public static DialogBigText Instance(string Title, string Text, string ButtonMain, string ButtonSecond, Action<DialogResult> main)
        {
            lock (_instanceLock)
            {
                if (Title is null or "")
                {
                    throw new ArgumentNullException("title");
                }

                if (Text is null or "")
                {
                    throw new ArgumentNullException("text");
                }

                if (_instance == null)
                {
                    _instance = new DialogBigText(Title, Text, ButtonMain, ButtonSecond, main);
                }
                return _instance;
            }
        }

        private DialogBigText(string Title, string Text, string ButtonMain, string ButtonSecond, Action<DialogResult> main)
        {
            InitializeComponent();

            this.FormClosing += (sender, e) =>
            {
                if (!_isActed)
                {
                    e.Cancel = true;
                }

                _instance = null;
            };

            bntMain.Text = ButtonMain;
            bntSecond.Text = ButtonSecond;
            lblTitle.Text = Title;
            mainText.Text = Text;
            MainAction = main;
        }


        private void DialogBigText_Load(object sender, EventArgs e)
        {

        }

        private void bntMain_Click(object sender, EventArgs e)
        {
            MainAction?.Invoke(DialogResult.OK);

            _isActed = true;

            this.Close();
        }

        private void bntSecond_Click(object sender, EventArgs e)
        {
            MainAction?.Invoke(DialogResult.Cancel);

            _isActed = true;

            this.Close();
        }

        private void DialogBigText_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_isActed)
            {
                e.Cancel = true;
            }
            _instance = null;
        }

        private void DialogBigText_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}

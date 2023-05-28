using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABLibary.Forms
{
    public static class AsyncMessageBox
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly uint SWP_NOMOVE = 0x0002;
        private static readonly uint SWP_NOSIZE = 0x0001;
        private static readonly uint SWP_SHOWWINDOW = 0x0040;
        [DllImport("user32")]
        private static extern IntPtr FindWindow(string PstrClassName, string PstrCaption);
        [DllImport("user32")]
        private static extern void SetWindowPos(IntPtr PintWnd, IntPtr PintWndInsertAfter, int PintX, int PintY, int PintCx, int PintCy, uint uFlags);
        public delegate void MessageBoxClosedHandler(object PobjSender, MessageBoxClosedEventArgs PobjEventArgs);
        public static event MessageBoxClosedHandler MessageBoxClosed;
        private static bool MbolAlreadyShowing = false;
        /// <summary>
        /// Shows an asyncronous dialog
        /// Fires the MessageBoxClosed event when it is closed.
        /// This is a static messagebox, so only one can be displayed at a time
        /// Once called, the event handler is detached
        /// </summary>
        /// <param name="PstrText">The message in the message box</param>
        /// <param name="PstrCaption">The cpation on the message box</param>
        /// <param name="PobjButtons">The buttons for the message box</param>
        /// <param name="PobjIcon">The icon for the messafe box</param>
        /// <param name="PobjDefault">The default button selected in the messagebox</param>
        /// <returns></returns>
        public static bool Show(string PstrText, string PstrCaption = "", MessageBoxButtons PobjButtons = MessageBoxButtons.OK, MessageBoxIcon PobjIcon = MessageBoxIcon.None, MessageBoxDefaultButton PobjDefault = MessageBoxDefaultButton.Button1)
        {
            try
            {
                if (MbolAlreadyShowing) return false; // failed - already displayed
                DialogResult LobjResult = DialogResult.None;
                // start a thread to show the dialog
                new Thread(() => {
                    MbolAlreadyShowing = true;
                    LobjResult = MessageBox.Show(PstrText, PstrCaption, PobjButtons, PobjIcon, PobjDefault);
                    MbolAlreadyShowing = false;
                }).Start();
                // start a separate thread to wait for the result from above
                new Thread(() => {
                    // now make it topmost
                    IntPtr LintHwnd = FindWindow("#32770", PstrCaption);
                    SetWindowPos(LintHwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_SHOWWINDOW);
                    // Stay here until we get a result
                    while (LobjResult == DialogResult.None)
                    {
                        Thread.Sleep(10);
                        Application.DoEvents();
                    }
                    // create a hidden form so we can invoke back to the UI thread
                    // otherwise anyone attached to the event handler will get an 
                    // exception if they try anything with the UI
                    using (System.Windows.Forms.Form LobjForm = new System.Windows.Forms.Form { ShowInTaskbar = false, Opacity = 0 })
                    {
                        LobjForm.Show(); // show hidden form - ui thread
                        // fire the event
                        LobjForm.Invoke(new Action(() => {
                            MessageBoxClosed?.Invoke(new object(), new MessageBoxClosedEventArgs(LobjResult));
                            MessageBoxClosed = null; // important to release this
                        }));
                        LobjForm.Close(); // close hidden form
                    }
                }).Start();

                return true; // created
            }
            catch
            {
                return false; // failed
            }
        }
    }

    /// <summary>
    /// Event arguments for an AsyncMessageBox
    /// </summary>
    public class MessageBoxClosedEventArgs
    {
        public DialogResult Result { get; private set; }
        public MessageBoxClosedEventArgs(DialogResult PobjResult)
        {
            Result = PobjResult;
        }
    }
}

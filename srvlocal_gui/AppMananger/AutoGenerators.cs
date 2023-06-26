using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui.AppMananger
{
    public class AutoGenerators
    {
        public static void ShowReadMeDialog()
        {
            if (!File.Exists(".\\license.labl") && !LAB.SETTINGS.config.Default.acceptedLicenseAgrement)
            {
                string message = @" Dear User,

                                        Before you can use this software, you must read and agree to the terms and conditions of the license agreement below.

                                        License Agreement

                                        This software is licensed to you by JW Limited under the terms and conditions of the following license agreement. By using this software, you are agreeing to be bound by the terms and conditions of this agreement.

                                        1. Ownership and Copyright

                                        The developer is the owner of all intellectual property rights in the software. The software is protected by copyright laws and international treaties. You acknowledge that no title to the intellectual property in the software is transferred to you. You further acknowledge that title and full ownership rights to the software will remain the exclusive property of the developer and/or its suppliers.

                                        2. License Grant

                                        The developer grants you a non-exclusive, non-transferable, limited license to use the software, subject to the terms and conditions of this agreement. You may install and use the software on one computer only. You may not distribute, sublicense, or make available copies of the software to third parties.

                                        3. Restrictions

                                        You may not decompile, reverse engineer, disassemble, or otherwise attempt to derive the source code for the software. You may not modify, adapt, translate, or create derivative works based on the software. You may not remove or alter any copyright, trademark, or other proprietary notices from the software.

                                        4. Disclaimer of Warranties

                                        THE SOFTWARE IS PROVIDED 'AS IS' WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. THE DEVELOPER DOES NOT WARRANT THAT THE SOFTWARE WILL MEET YOUR REQUIREMENTS OR THAT THE OPERATION OF THE SOFTWARE WILL BE UNINTERRUPTED OR ERROR-FREE.

                                        5. Limitation of Liability

                                        IN NO EVENT SHALL THE DEVELOPER BE LIABLE FOR ANY INDIRECT, INCIDENTAL, SPECIAL, OR CONSEQUENTIAL DAMAGES ARISING OUT OF OR IN CONNECTION WITH THE USE OR INABILITY TO USE THE SOFTWARE (INCLUDING, BUT NOT LIMITED TO, LOSS OF PROFITS, BUSINESS INTERRUPTION, OR LOSS OF INFORMATION), EVEN IF THE DEVELOPER HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. IN ANY EVENT, THE DEVELOPER'S TOTAL LIABILITY TO YOU FOR ALL DAMAGES, LOSSES, AND CAUSES OF ACTION (WHETHER IN CONTRACT, TORT (INCLUDING NEGLIGENCE), OR OTHERWISE) SHALL NOT EXCEED THE AMOUNT PAID BY YOU FOR THE SOFTWARE.

                                        Please click 'Agree' to indicate that you have read and accepted the terms and conditions of this license agreement. If you do not agree to these terms, please click 'Disagree' and do not use the software.

                                        Thank you for using our software.

                                        Best regards,
                                        JW Limited.";

                var result = MessageBox.Show(message, "License Agreement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    LAB.SETTINGS.config.Default.acceptedLicenseAgrement = true;
                    LAB.SETTINGS.config.Default.Save();
                    LABLibary.Assistant.WriteLicense.Write(AppDomain.CurrentDomain.BaseDirectory);
                }
                else
                {
                    Application.ExitThread();
                }
            }
            else
            {
                LABLibary.Assistant.WriteLicense.Write(AppDomain.CurrentDomain.BaseDirectory);
            }
        }

        public static string ShowVersion()
        {
            return String.Format("JW Lmt. LILO� SrvLocal - [Local Server Application Host] version {0}", AssemblyVersion);
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string ShowHelp()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Usage: srvlocal.exe [OPTIONS]");
            sb.AppendLine();
            sb.AppendLine("Options:");
            sb.AppendLine("  --port=<port>");
            sb.AppendLine("      Specify the port to listen on (default is 8080)");
            sb.AppendLine();
            sb.AppendLine("  --media-folder=<folder>");
            sb.AppendLine("      Specify the folder to serve media data from (default is req/media)");
            sb.AppendLine();
            sb.AppendLine("  --folder=<folder>");
            sb.AppendLine("      Specify the folder to serve data from (default is dist/)");
            sb.AppendLine();
            sb.AppendLine("  --disable-logging");
            sb.AppendLine("      Disable request logging (default is enabled)");
            sb.AppendLine();
            sb.AppendLine("  --logfile=<file>");
            sb.AppendLine("      Specify the file to log requests to (default is access.log)");
            sb.AppendLine();
            sb.AppendLine("  --auth");
            sb.AppendLine("      Enable authentication for accessing the server");
            sb.AppendLine();
            sb.AppendLine("  --username=<username>");
            sb.AppendLine("      Specify the username for authentication");
            sb.AppendLine();
            sb.AppendLine("  --password=<password>");
            sb.AppendLine("      Specify the password for authentication");
            sb.AppendLine();
            sb.AppendLine("  --version");
            sb.AppendLine("      Show the current version");
            sb.AppendLine();
            sb.AppendLine("  --help");
            sb.AppendLine("      Show this help message");
            sb.AppendLine();
            sb.AppendLine("Examples:");
            sb.AppendLine("  srvlocal.exe --port=8000 --folder=public");
            sb.AppendLine("      Start the server on port 8000 and serve data from the 'public' folder");
            sb.AppendLine();
            sb.AppendLine("  srvlocal.exe --media-folder=data --disable-logging");
            sb.AppendLine("      Start the server and serve media data from the 'data' folder without logging");
            sb.AppendLine();
            sb.AppendLine("  srvlocal.exe --auth --username=admin --password=123456");
            sb.AppendLine("      Enable authentication with the username 'admin' and password '123456'");

            return sb.ToString();
        }
    }
}

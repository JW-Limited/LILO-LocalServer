using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace LABLibary.Assistant
{
    public class DirectoryIconSetter
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHGetSetFolderCustomSettings(ref SHFOLDERCUSTOMSETTINGS pfcs, string pszPath, uint dwReadWrite);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHFOLDERCUSTOMSETTINGS
        {
            public uint dwSize;
            public uint dwMask;
            public IntPtr pvid;
            public string pszWebViewTemplate;
            public uint cchWebViewTemplate;
            public string pszWebViewTemplateVersion;
            public string pszInfoTip;
            public uint cchInfoTip;
            public IntPtr pclsid;
            public uint dwFlags;
            public string pszIconFile;
            public uint cchIconFile;
            public int iIconIndex;
            public string pszLogo;
            public uint cchLogo;
        }

        public static void SetDirectoryIcon(string directoryPath, string iconFilePath, int iconIndex)
        {
            var settings = new SHFOLDERCUSTOMSETTINGS
            {
                dwSize = (uint)Marshal.SizeOf(typeof(SHFOLDERCUSTOMSETTINGS)),
                dwMask = 0x10,
                pszIconFile = iconFilePath,
                cchIconFile = (uint)iconFilePath.Length,
                iIconIndex = iconIndex,
                pszLogo = null,
                cchLogo = 0
            };

            int result = SHGetSetFolderCustomSettings(ref settings, directoryPath, 0x02);
            if (result != 0)
            {
                throw new ApplicationException("Failed to set the directory icon.");
            }
        }
    }

}

using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABLibary.Assistant
{
    public class ShortcutCreator
    {
        public static void CreateShortcut(string shortcutName, string targetFile)
        {
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\" + shortcutName + ".lnk";

            IWshShell wshShell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)wshShell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = targetFile;
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetFile);
            shortcut.WindowStyle = 1; // Normal window
            shortcut.Description = "Shortcut created using C#"; // Optional
            shortcut.IconLocation = targetFile + ",0"; // Optional

            shortcut.Save();
        }
    }
}

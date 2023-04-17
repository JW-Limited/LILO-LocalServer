# LAB Libary

This Libary you can use to build and develop apps with the lilo ecosystem build in.

It includes :
- UI Elements : WinUI, WinForms, Xaml
- Converters  : any type of data conversion
- Api Classes : many easy realisable api classes
- LILO SYS    : an easy to use system entry to LILO

## Repo

This project is also included in srvlocal. Its an Libary/Engine for JW Limited Apps.

## How to use it?

Just include this in youre Project and mark it on youre Codefile.
```CSharp
using LABLibary;
```

Example 1 : APICollection
```CSharp
if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("LILO\\local\\DebuggerMode") == "enabled") advancedDebug = true;
```
```CSharp
public void ConsoleHandler()
    {
        Interface.ApiCollection.WinRegistry.Keys keys = new Interface.ApiCollection.WinRegistry.Keys();

        if (keys.GetKeyValue("LILO\\local\\DebuggerMode") == "enabled")
        {
            var handle = AllocConsole();
            ShowWindow(handle, SW_SHOW);
        }
        else
        {
            openInExtraWindow = false;
            try
            {
                keys.SetKeyValue("DebuggerMode", "disabled");
            }
            catch (Exception msg) { Logger.Error(msg); }
        }
    }
```
Example 2 : Form Collection
```CSharp
LABLibary.Forms.InfoDialog.Show(ShowVersion(), "Version");

private static string ShowVersion()
{
    return String.Format("AppName Version {0}", AssemblyVersion);
}
```

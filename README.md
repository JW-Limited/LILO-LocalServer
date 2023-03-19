# LILO-LocalServer
***
## Repo

This Repositry and the Project are both in the very beginning of their creation.
Please be Patient.

### Finale Release Date : June

# LAB Libary
***
## Repo

This project is also included in srvlocal. Its an Libary/Engine for JW Limited Apps.

## How to use it?

Just include this in youre Project and mark it on youre Codefile.
```CSharp
using LABLibary;
```

Example 1 : APICollection
```CSharp
if (LABLibary.Interface.ApiCollection.WinRegistry.Keys.GetKeyValue("DebuggerMode") == "enabled") advancedDebugg = true;
```
```CSharp
public void ConsoleHandler()
    {
        Interface.ApiCollection.WinRegistry.Keys keys = new Interface.ApiCollection.WinRegistry.Keys();

        if (keys.GetKeyValue("DebuggerMode") == "enabled")
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
## Help

If you want to know how to use LILO LocalServer start it with the _--help_ argument

Response :


## Troubleshooting

If you had any trouble with the binary 

- start with higher Rights 
- use the Argument _--help-error-fix_ to fix it

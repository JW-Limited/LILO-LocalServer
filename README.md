# LILO LocalServer - Your Lightweight Local Web Server
LILO LocalServer is a lightweight local server that allows you to run a web application locally on your machine. It is designed to be easy to use, fast, and flexible.

## Features
- Local server for hosting web applications and serving static files
- Support for multiple simultaneous connections
- Secure HTTPS connections with automatic certificate generation and renewal
- Customizable logging and error reporting
- Websockets support for real-time communication between client and server
- Support for CORS headers to enable cross-origin requests
- Simple and intuitive configuration options
- Console and GUI overlay for easy management
- Configurable using a JSON file
- Can be run as a Windows service
## Installation
#### With Installer
To install LILO LocalServer, simply download the latest release from the releases page and run the installer.
#### With Command-Line
To install LILO-LocalServer, you need to build it with a .NET compiler. Here are the steps to follow:

Clone the repository:
```bash
git clone https://github.com/JW-Limited/LILO-LocalServer.git
cd LILO-LocalServer
```

Build the project with a .NET compiler:

```bash
dotnet build
```
This will build the project and create the necessary binaries.

## Usage
To start the server, navigate to the bin directory and run the following command to recieve Commands:
```bash
srvlocal.exe --help
```
or Start it with 
```bash
srvlocal.exe --port=8080 --path=<youre_path> --enable-logging=false
```
This will start the server on the default port 8080. You can then access your web application by navigating to http://localhost:8080 in your web browser.

## Config
You can easily configure the Application through the SettingsGUI or trough the JSON File

Some of the available configuration options include:

- The port number to use for the server
- The directory to serve static files from
- The logging level for the server
- The SSL certificate and key files to use for HTTPS connections
- CORS headers configuration
For more information on configuring LILO-LocalServer, please refer to the comments in the config.json file.

Here's an example config.json file:
```JSON
{
  "WindowTitle": "LILO-LocalServer",
  "ProductVersion": 42,
  "InstalledCorrectly": true,
  "CustomPortConfig": false,
  "CustomCDNConfig": false,
  "Port": 8080,
  "https": {
    "enabled": true,
    "certPath": "cert.pfx",
    "certPassword": "password"
  },
  "basicAuth": {
    "enabled": true,
    "users": [
      {
       "IsActivated": true,
       "UserName": "admin",
       "HashedPassword": "zlnKOf5ALuFLfGNLKC8jTQ==|ygAseQUn893vs3Vl8LIEvTFSqXpkB2OV5Uadjyuqzzc=",
       "CanChangeConfig": true
      }
  ]},
  "cors": {
    "enabled": true,
    "allowedOrigins": [
      "http://localhost:4200",
      "https://example.com"
    ]
  },
  "applications": [
    {
      "name": "My Web App",
      "path": "C:\\MyWebApp",
      "startCommand": "dotnet run"
    },
    {
      "name": "My Other Web App",
      "path": "C:\\MyOtherWebApp",
      "startCommand": "npm start"
    }
  ]
}
```

LILO-LocalServer also includes a console and GUI overlay for easy management. To launch the console overlay, run the following command:

```bash
dotnet LILO-LocalServer.Console.dll
```
To launch the GUI overlay, double-click on the LILO-LocalServer.GUI.exe file in the bin directory.

## Implement in Youre App
We currently working on the Package but until you can use the WindowsApi Implementation

```c#
using System;
using System.Diagnostics;
using System.IO;

class Program {
    static void Main(string[] args) {
        string executablePath = Path.Combine(Directory.GetCurrentDirectory(), "LILO.LocalServer.exe");

        if (!File.Exists(executablePath)) {
            Console.Error.WriteLine("LILO LocalServer executable not found");
            return;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo {
            FileName = executablePath,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        Process process = new Process {
            StartInfo = startInfo
        };
        process.OutputDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data)) {
                Console.WriteLine($"LILO LocalServer output: {e.Data}");
            }
        };
        process.ErrorDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data)) {
                Console.Error.WriteLine($"LILO LocalServer error: {e.Data}");
            }
        };
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();
        Console.WriteLine($"LILO LocalServer exited with code {process.ExitCode}");
    }
}
```

## Contributing
We welcome contributions to LILO-LocalServer! If you have any suggestions or improvements, please feel free to open an issue or pull request.

## License
LILO-LocalServer is licensed under the MIT License. See the LICENSE file for more information.

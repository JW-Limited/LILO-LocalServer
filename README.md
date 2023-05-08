# LILO-LocalServer
LILO-LocalServer is a local web server for hosting web applications and serving static files. It allows web developers and designers to test and debug their applications locally without the need for an external server.

## Features
- Local server for hosting web applications and serving static files
- Support for multiple simultaneous connections
- Secure HTTPS connections with automatic certificate generation and renewal
- Customizable logging and error reporting
- Websockets support for real-time communication between client and server
- Support for CORS headers to enable cross-origin requests
- Simple and intuitive configuration options
- Console and GUI overlay for easy management
## Installation
To install LILO-LocalServer, you need to build it with a .NET compiler. Here are the steps to follow:
Clone the repository:
```Bash
git clone https://github.com/JW-Limited/LILO-LocalServer.git
cd LILO-LocalServer
```

Build the project with a .NET compiler:

```
dotnet build
```
This will build the project and create the necessary binaries.

## Usage
To start the server, navigate to the bin directory and run the following command:
```
dotnet LILO-LocalServer.dll
```
This will start the server on the default port 8080. You can then access your web application by navigating to http://localhost:8080 in your web browser.

LILO-LocalServer also includes a console and GUI overlay for easy management. To launch the console overlay, run the following command:

```
dotnet LILO-LocalServer.Console.dll
```
To launch the GUI overlay, double-click on the LILO-LocalServer.GUI.exe file in the bin directory.

## Configuration
LILO-LocalServer can be easily configured to suit your needs. Configuration options are stored in the config.json file, which is located in the root directory of the project.

Some of the available configuration options include:

- The port number to use for the server
- The directory to serve static files from
- The logging level for the server
- The SSL certificate and key files to use for HTTPS connections
- CORS headers configuration
For more information on configuring LILO-LocalServer, please refer to the comments in the config.json file.

## Contributing
We welcome contributions to LILO-LocalServer! If you have any suggestions or improvements, please feel free to open an issue or pull request.

## License
LILO-LocalServer is licensed under the MIT License. See the LICENSE file for more information.

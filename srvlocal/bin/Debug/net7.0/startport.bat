@echo off
start /b srvlocal.exe --port=8080

:loop
timeout /t 1 >nul
tasklist /fi "imagename eq srvlocal.exe" 2>NUL | find /I "srvlocal.exe">NUL
if "%ERRORLEVEL%"=="0" goto loop
echo srvlocal.exe not running
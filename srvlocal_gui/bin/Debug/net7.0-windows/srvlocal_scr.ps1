$processName = "srvlocal"

while($true) {
    $process = Get-Process -Name $processName -ErrorAction SilentlyContinue

    if(!$process) {
        Write-Host "Process $processName is not running. Restarting..."
        Start-Process -FilePath ".\srvlocal.exe"
    }
    else {
        $process.WaitForExit()
        Write-Host "Process $processName has exited. Ending script."
    }

    Start-Sleep -Seconds 10
}
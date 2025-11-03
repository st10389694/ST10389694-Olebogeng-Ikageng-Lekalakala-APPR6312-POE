# verify-deployment.ps1
$AppUrl = "https://gift-of-givers-st10389694.azurewebsites.net"
$LogFile = "./docs/Deployment_Verification_Report.txt"
Write-Host "Verifying $AppUrl ..."
Add-Content $LogFile "Deployment verification - $(Get-Date)"
for ($i=1; $i -le 5; $i++) {
  try {
    $start = Get-Date
    $r = Invoke-WebRequest -Uri $AppUrl -UseBasicParsing -TimeoutSec 10
    $elapsed = (Get-Date - $start).TotalMilliseconds
    Add-Content $LogFile "Attempt $i: $($r.StatusCode) - $elapsed ms"
  } catch { Add-Content $LogFile "Attempt $i: ERROR - $($_.Exception.Message)" }
}

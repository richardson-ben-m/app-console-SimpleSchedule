
$buildPath = "SimpleSchedule.UI\bin\Release\net7.0"
$releasePath = "$env:USERPROFILE\SimpleSchedule"
$fileBase = "SimpleSchedule.UI"
Write-Output "Releasing program from $buildPath to $releasePath"

if (!(Test-Path $releasePath -PathType Container)) {
	New-Item -ItemType Directory -Force -Path $releasePath}

Copy-Item -Path "$buildPath\$fileBase.exe" -Destination $releasePath
Copy-Item -Path "$buildPath\$fileBase.dll" -Destination $releasePath
Copy-Item -Path "$buildPath\$fileBase.deps.json" -Destination $releasePath
Copy-Item -Path "$buildPath\$fileBase.runtimeconfig.json" -Destination $releasePath
	
Write-Output "Starting program..."
Start-Process "$releasePath\$fileBase.exe" 

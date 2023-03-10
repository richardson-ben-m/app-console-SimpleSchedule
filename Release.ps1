$buildPath = "Startup\bin\Release\net7.0"
$releasePath = "$env:USERPROFILE\SimpleSchedule"
$fileBase = "SimpleSchedule"
Write-Output "Releasing program from $buildPath to $releasePath"

if (!(Test-Path $releasePath -PathType Container)) {
	New-Item -ItemType Directory -Force -Path $releasePath}

$dlls = Get-ChildItem -File -Path $buildPath -Filter "*.dll" | % {$_.FullName}
Foreach ($file in $dlls)
{
	Write-Debug "Copying file: $file"
	Copy-Item -Path $file -Destination $releasePath
}

$jsons = Get-ChildItem -File -Path $buildPath -Filter "*.json" | % {$_.FullName}
Foreach ($file in $jsons)
{
	Write-Debug "Copying file: $file"
	Copy-Item -Path $file -Destination $releasePath
}

$exes = Get-ChildItem -File -Path $buildPath -Filter "*.exe" | % {$_.FullName}
Foreach ($file in $exes)
{
	Write-Debug "Copying file: $file"
	Copy-Item -Path $file -Destination $releasePath
}
	
Write-Output "Starting program..."
Start-Process "$releasePath\$fileBase.exe" 

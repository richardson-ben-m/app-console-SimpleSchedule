& ".\Build.ps1"

if ($LastExitCode -eq 0)
{
	Write-Output "The Build succeeded! I am releasing now."
	& ".\Release.ps1"
}
else
{
	Write-Output "The Build failed! I am not releasing anything."
}
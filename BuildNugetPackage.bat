@echo off

setlocal EnableDelayedExpansion

if not exist nuget.exe (
	echo Nuget not found, trying to download it ...

	where /q powershell

	if !ERRORLEVEL! neq 0 (
		echo Powershell not found, aborting !
		goto eof
	)

	powershell -command "& {iwr https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile nuget.exe}"
)

if not exist nuget.exe (
	echo Nuget couldn't be downloaded, aborting !
	goto eof
)

echo Building package ...
nuget pack BinaryExtensions\BinaryExtensions.csproj -Build -Symbols -Properties Configuration=Release

:eof
endlocal
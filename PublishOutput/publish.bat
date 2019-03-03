set /p key=<key.txt
nuget push Techl.2.0.0.nupkg %key% -Source https://api.nuget.org/v3/index.json
pause
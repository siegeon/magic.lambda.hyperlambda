
set version=%1
set key=%2

cd %~dp0

dotnet build magic.lambda.hyperlambda/magic.lambda.hyperlambda.csproj --configuration Release --source https://api.nuget.org/v3/index.json
dotnet nuget push magic.lambda.hyperlambda/bin/Release/magic.lambda.hyperlambda.%version%.nupkg -k %key% -s https://api.nuget.org/v3/index.json

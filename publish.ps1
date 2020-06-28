$scriptPath = $MyInvocation.MyCommand.Path
$dir = Split-Path -Parent $scriptPath

cd $dir
rm publish.zip
cd OnlyJournalPage/bin/Release/netcoreapp3.1
dotnet publish --configuration Release
D:/Applications/7-Zip/7z.exe u ($dir + "/publish.zip") publish
cd $dir
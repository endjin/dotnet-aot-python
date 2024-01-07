$dotnetInfo = dotnet --info
$runtimeIdentifier = $dotnetInfo | Select-String -Pattern "RID:" | ForEach-Object { $_.ToString().Split(":")[1].Trim() }

dotnet publish ./dotnet/daeta.utils/solutions/daeta.utils/daeta.utils.csproj -r $runtimeIdentifier -o ./artefacts/$runtimeIdentifier/

python ./python/dotnet-native-lib.py "$runtimeIdentifier"
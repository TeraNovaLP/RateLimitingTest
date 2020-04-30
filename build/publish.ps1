function publishApp() {
    $binFolderPath = "../RateLimitingTest/bin";

    if (Test-Path $binFolderPath) {
        Remove-Item $binFolderPath -R -Force;
    }

    Set-Location ../
    dotnet clean
    dotnet publish -c Release
}

publishApp

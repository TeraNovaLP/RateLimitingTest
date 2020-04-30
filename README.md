# RateLimitingTest
With this tool, you can spawn a given amount of simultaneous GET-Request to trigger the rate limiting of a website or API. As result, you get an overview over all executed request and their response from the target. So you can verify that the implemented rate limit is working as expected.

## Usage
**It is possible that you must first install .NET Core 3.1 to run this tool!**
1. Download the latest [Release](https://github.com/TeraNovaLP/RateLimitingTest/releases) and unzip it.
2. Go in the unzipped folder and execute the **RateLimitingTest.exe**.
3. Then follow the instructions in the opened window

## Development
### Build executable
Execute the publish.ps1 script in the build directory of the project to publish the app:
```
./publish.ps1
```

The executable files can then be found in the folder ``RateLimitingTest/bin/Release/netcoreapp3.1/publish``.

# device-rest-service-dotnet
This project exposes the backend apis for the DevicePortalReactNative project

# run
dotnet <Path>device-rest-service-dotnet/DeviceApp/DeviceApp.api/bin/Debug/netcoreapp3.1/DeviceApp.api.dll

# create new library
dotnet new classlib -o DeviceApp.util.lib

# create new test project
dotnet new xunit -n DeviceApp.api.test

# add dependency to sln
dotnet sln add .\DeviceApp.api.lib\DeviceApp.api.lib.csproj

# build
dotnet build

# run test
dotnet test
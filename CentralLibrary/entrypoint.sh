set -e

dotnet ef database update --no-build

dotnet CentralLibrary.dll
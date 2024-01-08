#!/bin/bash

set -e

cd /app

# Apply migrations using the compiled DLL
dotnet ef database update --no-build --project CentralLibrary.csproj

# Start the application
dotnet CentralLibrary.dll

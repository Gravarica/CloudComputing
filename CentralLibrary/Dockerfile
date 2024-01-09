# Build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:5292

# Copy csproj and restore any dependencies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the entrypoint to the .NET application
ENTRYPOINT ["dotnet", "CentralLibrary.dll"]

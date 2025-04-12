# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.comdotnetsdk6.0 AS build
WORKDIR app

# Copy csproj and restore
COPY .csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image
FROM mcr.microsoft.comdotnetaspnet6.0
WORKDIR app
COPY --from=build appout .

# Expose port for Railway
EXPOSE 8080

ENTRYPOINT [dotnet, WebUniversity.dll]

# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy .csproj and restore dependencies
COPY WebUniversity/WebUniversity.csproj ./WebUniversity/
RUN dotnet restore ./WebUniversity/WebUniversity.csproj

# Copy all source and build
COPY . .
WORKDIR /src/WebUniversity
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebUniversity.dll"]

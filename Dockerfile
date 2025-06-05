# Use the official .NET 8 runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["ClassCompassApi.csproj", "ClassCompassApi/"]
COPY ["../ClassCompass.Shared/ClassCompass.Shared.csproj", "ClassCompass.Shared/"]

# Restore dependencies
RUN dotnet restore "ClassCompassApi/ClassCompassApi.csproj"

# Copy all source code
COPY . ClassCompassApi/
COPY ../ClassCompass.Shared ClassCompass.Shared/

# Build the application
WORKDIR "/src/ClassCompassApi"
RUN dotnet build "ClassCompassApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "ClassCompassApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage - runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassCompassApi.dll"]
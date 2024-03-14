#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestBuild.csproj", "./"]
RUN dotnet restore ./TestBuild.csproj
COPY . .
WORKDIR /src
RUN dotnet build TestBuild.csproj -c $BUILD_CONFIGURATION -o /app

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish TestBuild.csproj -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TestBuild.dll"]
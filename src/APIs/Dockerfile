#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/APIs/DocumentArchive.APIs.csproj", "src/APIs/"]
COPY ["src/Application/DocumentArchive.Application.csproj", "src/Application/"]
COPY ["src/Common/DocumentArchive.Common.csproj", "src/Common/"]
COPY ["src/Domain/DocumentArchive.Domain.csproj", "src/Domain/"]
COPY ["src/Infrastracture/DocumentArchive.Infrastructure.csproj", "src/Infrastracture/"]
RUN dotnet restore "./src/APIs/DocumentArchive.APIs.csproj"
COPY . .
WORKDIR "/src/src/APIs"
RUN dotnet build "./DocumentArchive.APIs.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DocumentArchive.APIs.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocumentArchive.APIs.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/paynau.jccm.project.Api/paynau.jccm.project.Api.csproj", "src/paynau.jccm.project.Api/"]
RUN dotnet restore "./src/paynau.jccm.project.Api/paynau.jccm.project.Api.csproj"
COPY . .
WORKDIR "/src/src/paynau.jccm.project.Api"
RUN dotnet build "./paynau.jccm.project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./paynau.jccm.project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "paynau.jccm.project.Api.dll"]
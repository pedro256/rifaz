#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 3000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["App.Rifas.Core.Api/App.Rifas.Core.Api.csproj", "App.Rifas.Core.Api/"]
RUN dotnet restore "App.Rifas.Core.Api/App.Rifas.Core.Api.csproj"
COPY . .
WORKDIR "/src/App.Rifas.Core.Api"
RUN dotnet build "App.Rifas.Core.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.Rifas.Core.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Rifas.Core.Api.dll"]
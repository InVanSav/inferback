﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["inferback.csproj", "."]
RUN dotnet restore "inferback.csproj"
COPY . .
RUN dotnet build "inferback.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "inferback.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "inferback.dll"]

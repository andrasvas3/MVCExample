FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet build -c Release
RUN dotnet publish -c Release

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/src/MVCExample/bin/Release/net10.0/publish/ .

ENV ASPNETCORE_URLS=http://*:8080

ENTRYPOINT ["dotnet", "MVCExample.dll"]

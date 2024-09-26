FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080 
EXPOSE 8081  
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Gateway.API/Gateway.API.csproj", "Gateway.API/"]
RUN dotnet restore "./Gateway.API/Gateway.API.csproj"
COPY . .
WORKDIR "/src/Gateway.API"
RUN dotnet build "./Gateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Gateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.API.dll"]

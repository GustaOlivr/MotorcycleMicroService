FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8082
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todos os projetos de class libraries e o projeto principal
COPY ["MotorcycleMicroService.API/MotorcycleMicroService.API.csproj", "MotorcycleMicroService.API/"]
COPY ["MotorcycleMicroService.CrossCutting/MotorcycleMicroService.CrossCutting.csproj", "MotorcycleMicroService.CrossCutting/"]
COPY ["MotorcycleMicroService.Application/MotorcycleMicroService.Application.csproj", "MotorcycleMicroService.Application/"]
COPY ["MotorcycleMicroService.Domain/MotorcycleMicroService.Domain.csproj", "MotorcycleMicroService.Domain/"]
COPY ["MotorcycleMicroService.Persistense/MotorcycleMicroService.Persistense.csproj", "MotorcycleMicroService.Persistense/"]



# Restaurar dependências de todos os projetos
RUN dotnet restore "./MotorcycleMicroService.API/MotorcycleMicroService.API.csproj"

# Copiar o restante dos arquivos
COPY . .

# Construir o projeto
WORKDIR "/src/MotorcycleMicroService.API"
RUN dotnet build "./MotorcycleMicroService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./MotorcycleMicroService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MotorcycleMicroService.API.dll"]

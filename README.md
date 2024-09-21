
# MotorcycleMicroService API

O Projeto `MotorcycleMicroService API` é uma API RESTful projetada para o gerenciamento de motocicletas para atender como um dos microserviços de uma arquitetura para um sistema de gerenciamento de manutenções. Utiliza .NET 8 e outras tecnologias modernas para garantir uma arquitetura sólida e eficiente.

## Tecnologias Utilizadas

-   **.NET 8**: Framework para desenvolvimento da API.
-   **Entity Framework Core**: ORM para interagir com o banco de dados PostgreSQL.
-   **PostgreSQL**: Banco de dados relacional utilizado.
-   **AutoMapper**: Biblioteca para mapeamento de objetos entre camadas.
-   **Swagger**: Ferramenta para documentação da API e testes interativos.
-   **Dependency Injection (IoC)**: Gerenciamento de dependências e inversão de controle.

## Padrões de Design

-   **Repository Pattern**: Encapsula a lógica de acesso aos dados.
-   **Service Layer**: Camada responsável pela lógica de negócios.
-   **DTO (Data Transfer Object)**: Separa as entidades de domínio das representações de dados para entrada e saída.
-   **AutoMapper**: Automatiza o mapeamento entre entidades e DTOs.
-   **Dependency Injection (DI)**: Facilita a gestão de dependências.
-   **Object Relational Mapper**: Facilita o acesso a dados utilizando EF.


## Configuração do Projeto

### Pré-requisitos

-   .NET 8 SDK
-   PostgreSQL

### Configuração do Banco de Dados

1.  **Configurar a String de Conexão**
    
    No arquivo `appsettings.json`, configure a string de conexão:
    
    `{
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=manut_system_db;Username=seu_usuario;Password=sua_senha"
      }
    }` 
    
2.  **Instalar Entity Framework Core Tools**
    
    Caso ainda não esteja instalado, execute:
    
    `dotnet tool install --global dotnet-ef` 
    
### Migrações e Atualização do Banco de Dados usando comandos no Visual Studio com Package Manager Console

1.  **Criar Migrações**
    
    Navegue até a barra de ferramentas do Visual Studio e clique nas seguintes opções -> Tools -> NuGet Package Manager -> Package Manager Console, no terminal digite:

    `Add-Migration NomeDaMigracao`

2.  **Aplicar Migrações**

    Para atualizar o banco de dados com as migrações, execute:

    `update-database`

### Migrações e Atualização do Banco de Dados usando comandos em CMD

1.  **Criar Migrações**
    
    Navegue até o diretório do projeto de repositório e execute:
    
    `dotnet ef migrations add InitialCreate -p MotorcycleMicroService.Repository -s MotorcycleMicroService.API` 
    
2.  **Aplicar Migrações**
    
    Para atualizar o banco de dados com as migrações, execute:
    
    `dotnet ef database update -p ManutSystem.Repository -s ManutSystem.API` 
    

### Executar o Projeto

1.  Navegue até o diretório raiz do projeto da API e execute:
    
    `dotnet run` 
    
2.  A API estará disponível na URL padrão:
    
    `https://localhost:7147` (ou outra porta configurada).
    

## Injeção de Dependências

As dependências são configuradas no arquivo `NativeInjectorBootStrapper.cs` no projeto `MotorcycleMicroService.CrossCutting`. No arquivo `Program.cs` da API, registre os serviços com:

`builder.Services.RegisterServices(builder.Configuration.GetConnectionString("DefaultConnection"));` 

Certifique-se de declarar novos arquivos que utilizam injeção de dependência na classe `NativeInjectorBootStrapper.cs` para garantir o funcionamento adequado do projeto.
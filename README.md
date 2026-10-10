# Property Management System

A console-based property management application developed in C# with .NET 8. It supports managing landlords, tenants, properties, rental contracts, rent receipts, and property expenses.

## Features

- Create, update, remove, and list tenants and landlords
- Manage properties, including property type, location, monthly rent, and availability status
- Create and manage rental contracts
- Manage rent receipts and property expenses
- Persist data in binary files between runs

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Run the application

From the repository root, run:

```bash
dotnet run --project trabalhoPOO/trabalhoPOO.csproj
```

Alternatively, build the solution and run the executable from Visual Studio:

```bash
dotnet build trabalhoPOO.sln
```

## Data storage

The application loads and saves its data in the following files in its current working directory:

- `inquilinos.dat` — tenants
- `senhorios.dat` — landlords
- `imoveis.dat` — properties
- `contratos.dat` — contracts, including their receipts

Choose **Save all** in the menu to save manually. Data is also saved when the application exits.

## Project structure

- `trabalhoPOO/` — console application and menu
- `trabalhoPOO.atributos/` — domain entities and attributes
- `dados/` — repositories and data persistence
- `regras/` — business operations and validation
- `excecoes/` — custom exceptions

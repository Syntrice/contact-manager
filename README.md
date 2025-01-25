# Syntrice Contact Manager

![Animation](https://github.com/user-attachments/assets/333e2d9e-f159-435f-a62c-5497325c7799)

## About

**Syntrice Contact Manager** is a console application for managing contact
details. It is written in C# and built upon.
[.NET Generic Host](https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder).

## Technologies

- **Language:** C#
- **Frameworks:** .NET Generic Host, Spectre.Console
- **Data Management:** SQLite, Entity Framework Core
- **Tools:** Fluent Validations
- **Testing:** NUnit, Moq, Fluent Assertions
- **General:** State Machine, Dependency Injection, Layered Architecture,
    Repository Pattern, Options Pattern, Test Driven Development 

## Database Schema

![alt text](Resources/entity_relationship_diagram.drawio.svg)

## Setup

If you are running windows, the easiest way to build this solution is through Microsoft Visual Studio 2022. You will also need .NET 8.0 installed.

1. Clone the repository

```powershell
git clone "https://github.com/Syntrice/syntrice-contact-manager"
```

2. Navigate to repository root

```powershell
cd "./syntrice-contact-manager"
```

3. Restore dependencies

```powershell
dotnet restore
```

4. Build Project

```powershell
dotnet build "./ContactManager.sln"
```

## Licence


This project is licensed under the MIT License.
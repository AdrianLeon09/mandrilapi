# MandrilAPI
🇪🇸 ¿Hablas español? Visita el archivo [README-ES.md](./README-ES.md) en Español

🇧🇷 ¿Fala português? Visite o arquivo [README-PT-BR.md](./README-PT-BR.md) em Português ; 

# MandrilAPI

**MandrilAPI** is a RESTful Web API developed in **C\# with ASP.NET Core (.NET 8)** that simulates the management of a `Mandril` entity, which can be associated with a set of skills (`Skills`).

The application follows the principles of **clean architecture**, **separation of concerns**, and now includes a complete **authentication and authorization system based on JWT and ASP.NET Identity**.

-----

## 🆕 What's New and Recent Features

  - **JWT authentication and authorization system**: User registration, login, and logout; generation and validation of JWT tokens.
  - **User management**: Endpoints to get and update the authenticated user's data (name, last name, public username, email, date of birth).
  - **Roles and policies**: Support for `Admin` and `User` roles, with endpoints protected by policies and roles.
  - **Additional controllers**:
      - `AccountController`: User registration, login, and logout.
      - `UserDataController`: Querying and updating authenticated user's data.
      - `AdminController`: Advanced management of relationships and users (administrators only).
  - **Advanced validations**: Custom validations in DTOs for user registration and updates.
  - **Swagger with JWT support**: Interactive documentation and testing of authenticated endpoints.
  - **Custom error and success messages**: Clear and categorized messages for each operation.

-----

## Architecture and Design

  - **Clean Architecture**
  - Well-defined modular layer structure
  - Repository pattern with separation of read/write responsibilities
  - Dependency injection through interfaces
  - **ASP.NET Identity** for user and role management
  - **JWT** for secure authentication and authorization

## Database

  - Persistence in SQL Server using Entity Framework Core
  - Many-to-many relationship between `Mandril` and `Skills` with an intermediate table `MandrilSkills` and a `PowerMS` field
  - Migrations and entity configuration
  - User and role tables managed by Identity

## RESTful API

  - Main controllers:
      - `MandrilController`: Mandril administration (Admin only)
      - `SkillsController`: Skills administration (Admin only)
      - `MandrilSkillsController`: Handling of mandril-skill relationships (authenticated users)
      - `AccountController`: User registration, login, and logout
      - `UserDataController`: Management of authenticated user's data
      - `AdminController`: Advanced management of relationships and users (Admin only)
  - Endpoints following REST conventions
  - Documentation with Swagger (includes JWT authentication)

## Code Quality

  - Logging system (ILogger) for monitoring operations
  - Layered error handling with custom messages
  - Business and DTO validations for secure data transfer
  - Clean and documented code

-----

## 🎯 Project Goals

1.  Implementation of a scalable architecture in .NET
2.  Good practices in the development of secure APIs
3.  Handling of database relationships and user/role management
4.  Common design patterns in enterprise applications

-----

## 🚀 Upcoming Improvements

  - Automated tests

-----

## 🛠️ Technologies used

  - .NET 8
  - ASP.NET Core Web API
  - Entity Framework Core
  - ASP.NET Identity
  - JWT (Json Web Token)
  - Swagger
  - SQL Server
  - ILogger

-----

-----

## 📁 Project structure

```
📁 MandrilAPI (Project Root)
├── 📁 Aplication
│   ├── 📁 Interfaces
│   │   ├── 📄 IMandrilSkillsReadRepository.cs
│   │   └── 📄 IMandrilSkillsWriteRepository.cs
│   └── 📁 Service
│       ├── 📄 Functions.cs
│       ├── 📄 MessageDefaultsAdmin.cs
│       ├── 📄 MessageDefaultsDevs.cs
│       └── 📄 MessageDefaultsUsers.cs
├── 📁 Domain
│   └── 📁 Models
│       ├── 📄 Mandril.cs
│       └── 📄 Skill.cs
├── 📁 Infrastructure
│   ├── 📁 Authentication
│   │   ├── 📁 AuthDatabaseContext
│   │   ├── 📁 AuthenticationDTOs
│   │   ├── 📁 AuthModels
│   │   └── 📄 GenerateJwt.cs
│   ├── 📁 CustomAnnotations
│   ├── 📁 DatabaseContext
│   │   ├── 📄 MandrilDbContext.cs
│   │   └── 📄 MandrilWithSkillsIntermediateTable.cs
│   ├── 📁 ModelsDTOs
│   │   ├── 📄 MandrilDto.cs
│   │   ├── 📄 SkillDto.cs
│   │   └── 📄 UpdatePowerRequestDto.cs
│   └── 📁 Repositories
│       ├── 📄 MandrilSkillsReadRepository.cs
│       └── 📄 MandrilSkillsWriteRepository.cs
├── 📁 Presentation
│   ├── 📁 AuthenticationControllers
│   ├── 📁 Controllers
│   └── 📄 Program.cs
├── 📄 appsettings.json
├── 📄 README.md
├── 📄 README-ES.md
└── 📄 README-PT-BR.md
```

## 📚 Documentation with Swagger

When starting the project, Swagger is automatically loaded at:
https://localhost:(port)/swagger

There you can see and test all the available endpoints.

# 🧪 How to run the project

## How to run the project in Windows

This project can be run both from the command line and from an IDE like Visual Studio or Rider.

## Option 1: From the command line (PowerShell or CMD)

1.  **Clone the repository:**

<!-- end list -->

```
git clone https://github.com/AdrianLeon09/mandrilapi 

cd mandrilapi 
```

**2. Restore dependencies:**

```
dotnet restore
```

**3. Apply migrations to create the database:**

**Configure the connection string**

  - Open the `appsettings.json` file located in the project.
  - Verify that the connection string to the SQL Server database is correctly configured for your local environment.
  - Windows Example:

<!-- end list -->

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=mandrilDB;Trusted_Connection=true;TrustServerCertificate=True;"
}
```

  - Linux Example:

<!-- end list -->

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=mandrilDB;UserId=sa;Password=YourPassword123;TrustServerCertificate=True;"
}

```

**4. Apply the corresponding migrations to AuthDbContext and MandrilDbContext**

In the terminal, go to the project solution and type

```
dotnet ef migrations add NameOfMigration --context MandrilDbContext
```

```
dotnet ef migrations add NameOfMigration --context AuthDbContext
```

```
dotnet ef database update --context MandrilDbContext
```

```
dotnet ef database update --context AuthDbContext
```

**4. Run the application:**

dotnet run

**6. Open the Swagger documentation in your browser:**

` https://localhost:(port)/swagger/index.html  `

## Option 2: From Visual Studio

Follow these steps to open and run the project in Visual Studio 2022:

1.  **Open the project or solution**

      - Start Visual Studio 2022.

      - Select **Clone a repository**. and enter ` https://github.com/AdrianLeon09/mandrilapi  `

      - If you downloaded the repository directly:

      - Select **Open a project or solution**.

      - Navigate to the folder where you cloned the repository and select the `MandrilAPi.sln` (solution) file.

2.  **Restore dependencies**

      - Visual Studio will automatically detect the necessary NuGet packages and restore them.
      - You can check the progress in the **NuGet Package Manager** window or in the status bar.

3.  **Configure the connection string**

      - Open the `appsettings.json` file located in the project.
      - Verify that the connection string to the SQL Server database is correctly configured for your local environment.
      - Example:

    <!-- end list -->

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=mandrilDB;Trusted_Connection=true;TrustServerCertificate=True;"
    }
    ```

**4. Apply the corresponding migrations to AuthDbContext and MandrilDbContext**

Open the Package Manager Console from Tools \> NuGet Package Manager \> Package Manager Console.

Execute the following commands to create the migrations and update the database:

```
Add-Migration NameOfMigration -Context MandrilDbContext
```

```
Add-Migration NameOfMigration -Context AuthDbContext
```

```
Update-Database -context MandrilDbCOntext
```

```
Update-Database -context AuthDbContext 
```

5.  **Run the application**
    Press F5 to start the application in debugging mode, or Ctrl + F5 to run it without debugging.
    A browser window will automatically open with the Swagger documentation.

**(Optional - Accessing Swagger documentation manually )**

In the browser, access the URL: `http://localhost:(port)/swagger/index.html`
There you will be able to see the interactive documentation of the API and test the endpoints.

**NOTES**

  - Make sure you have Visual Studio 2022 installed with the **ASP.NET and web development** workload.

  - The assigned port may vary; check the one that appears in the address bar of the browser when the application starts.

  - If you make changes to the migrations, remember to apply Update-Database again to update the database.

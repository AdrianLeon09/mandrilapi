# MandrilAPI
🇪🇸 ¿Hablas español? Visita el archivo [README-ES.md](./README-ES.md) en Español

🇧🇷 ¿Fala português? Visite o arquivo [README-PT-BR.md](./README-PT-BR.md) em Português ; 

**MandrilAPI** is a RESTful Web API developed in **C\# with ASP.NET Core** that simulates the management of a `Mandril` entity, which can be associated with a set of `Skills`.

The application is structured following the principles of **Clean Architecture** and **separation of concerns**, making it ideal for learning how to scale and organize a project in a basic way.

The system includes three main controllers:

  - `MandrilController`
  - `SkillsController`
  - `MandrilSkillsController`

Each one manages its respective table in a **SQL Server database** through EF, with `MandrilSkills` being a **many-to-many** relationship table. The MandrilSkills table represents a many-to-many relationship between mandrills and skills, using composite primary keys. Additionally, it incorporates an extra column called PowerMS (MS = MandrilSkill), which indicates the assigned skill level from 0 to a maximum of 4.

This intermediate table was modeled manually with Entity Framework, which allows for greater control over its structure and behavior, considering the possible future scalability of the system and the incorporation of new features.

-----

## What does this project offer?

This practice project was built with the aim of going beyond the basics. It includes essential concepts for professional backend development:

### Architecture and Design

  - Implementation of **Clean Architecture**
  - Well-defined modular layer structure
  - Repository Pattern with read/write separation of concerns
  - Dependency injection using interfaces

### Database

  - Persistence in SQL Server using Entity Framework Core
  - Many-to-many relationship between `Mandril` and `Skills`
  - Intermediate table `MandrilSkills` with a `PowerMS` field for skill level
  - Migrations and entity configuration

### RESTful API

  - Three main controllers:
      - `MandrilController`: Manages mandrills
      - `SkillsController`: Manages skills
      - `MandrilSkillsController`: Handles mandrill-skill relationships
  - Endpoints following REST conventions
  - Documentation with Swagger

### Code Quality

  - Logging system (ILogger) for monitoring operations from the console
  - Layer-based error handling with custom messages
  - Business validations
  - DTOs for secure data transfer
  - Clean and documented code in English

## 🎯 Project Goals

This project is designed to demonstrate:

1.  Implementation of a scalable architecture in .NET
2.  Good practices in API development
3.  Handling database relationships
4.  Common design patterns in enterprise applications

## 🚀 Upcoming Improvements

  - Authentication/authorization system based on JWT and ASP.NET Identity.
  - Development of a user interface in Angular

-----

This project is **not intended to be advanced**, but it is ideal for any beginner who wants to learn initially:

  - How to structure a real API in a professional manner
  - What validations and errors should be considered in real-world projects
  - How to relate entities with a database using C\# and ASP.NET Core

-----

## 🛠️ Technologies Used

  - .NET 8
  - ASP.NET Core Web API
  - Entity Framework Core
  - Swagger
  - SqlServer
  - ILogger

-----

## 📁 Project Structure

```
/Presentation
├── Controllers
│   ├── MandrilController.cs
│   ├── SkillsController.cs
│   └── SkillsMandrilController.cs
├─ Program.cs
/Application
├── Interfaces
│   ├── IMandrilSkillsReadRepository.cs
│   └── IMandrilSkillsWriteRepository.cs
├── Services
│   ├── MessageDefaultsDevs.cs
│   └── MessageDefaultsUsers.cs
/Infrastructure
├── Repositories
│   ├── MandrilSkillsReadRepository.cs
│   └── MandrilSkillsWriteRepository.cs
├── DatabaseContext
│   ├── MandrilDbContext.cs
│   └── MandrilWithSkillsIntermediateTable.cs
├── DTOs
│   ├── MandrilDTO.cs
│   ├── SkillDTO.cs
│   └── PowerDTO.cs
├── Migrations
/Domain
├── Models
│   ├── Mandril.cs
│   └── Skill.cs´
```

## 📚 Documentation with Swagger

When you start the project, Swagger will automatically load at:
https://localhost:(port)/swagger

There you can see and test all available endpoints.

## 🧪 How to run the project

# How to run the project on Windows

This project can be run either from the command line or from an IDE like Visual Studio or Rider.

## Option 1: From the command line (PowerShell or CMD)

1.  **Clone the repository:**

<!-- end list -->

```
git clone https://github.com/AdrianLeon09/mandrilapi 

cd mandrilapi 
```

**3. Restore dependencies:**

```
dotnet restore
```

**3. Apply migrations to create or update the database:**

```
dotnet ef database update
```

**4. Run the application:**

dotnet run

**6. Open the Swagger documentation in your browser:**

` https://localhost:(port)/swagger/index.html  `

## Option 2: From Visual Studio

Follow these steps to open and run the project in Visual Studio 2022:

1.  **Open the project or solution**

      - Start Visual Studio 2022.

      - Select **Clone a repository** and enter ` https://github.com/AdrianLeon09/mandrilapi  `

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

4.  **Apply migrations**
    Open the Package Manager Console from Tools \> NuGet Package Manager \> Package Manager Console.

Run the following command to create or update the database:

` Update-Database  `

5.  **Run the application**
    Press F5 to start the application in debug mode, or Ctrl + F5 to run it without debugging.
    A browser window will open automatically with the Swagger documentation.

**(Optional - Access Swagger documentation manually)**

In your browser, go to the URL: `http://localhost:(port)/swagger/index.html`
There you will be able to see the interactive API documentation and test the endpoints.

**NOTES**

  - Make sure you have Visual Studio 2022 installed with the **ASP.NET and web development** workload.

  - The assigned port may vary; check the one that appears in the browser's address bar when the application starts.

  - If you make changes to the migrations, remember to run `Update-Database` again to update the database.

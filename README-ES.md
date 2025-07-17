# MandrilAPI

**MandrilAPI** es una API RESTful desarrollada en **C# con ASP.NET Core** que simula el manejo de una entidad `Mandril`, la cual puede estar asociada a un conjunto de habilidades (`Skills`). 

La aplicación está estructurada siguiendo principios de **arquitectura limpia** y **separación de responsabilidades**, lo que la hace ideal para aprender cómo escalar y organizar un proyecto profesional desde cero.

El sistema incluye tres controladores principales:
- `MandrilController`
- `SkillsController`
- `MandrilSkillsController`

Cada uno gestiona su respectiva tabla en una **base de datos SQL Server** por medio de EF, siendo `MandrilSkills` una tabla de relación **muchos a muchos** entre mandriles y habilidades incluyendo ademas una columna "PowerMS" para especificar un nivel de habilidad.

---

## ¿Qué aporta este proyecto?

Este proyecto de práctica fue construido con el objetivo de ir más allá de lo básico. Se incluyen conceptos esenciales para el desarrollo backend profesional:

- ✅ Estructura limpia y modular por capas (Controllers, Repositories, DTOs, Entities, MessagesDefaults..., etc)
- ✅ Persistencia real en base de datos SQL Server
- ✅ Separación de repositorios de lectura y escritura
- ✅ Uso de interfaces para fomentar la inyección de dependencias
- ✅ Uso de ILogger para registrar mensajes de éxito (LogInformation) y advertencia (LogWarning).
- ✅ Validaciones de negocio (por ejemplo: evitar duplicados, asociaciones inválidas, etc.)
- ✅ Manejo de errores bien definido por capa
- ✅ Convenciones RESTful y nombres claros en inglés
- ✅ Código limpio, organizado y con comentarios solo cuando son necesarios (en inglés)

  ## ¿Proximos pasos?
  
- Implementar JWT para autenticación y autorización.
- Desarrollar una interfaz de usuario (UI) con Angular para consumir la API.

---
Este proyecto **no pretende ser avanzado**, pero es ideal para cualquier principiante que quiera aprender de forma inicial:
- Cómo estructurar una API real de manera profesional
- Qué validaciones y errores deben considerarse en proyectos del mundo real
- Cómo relacionar entidades con una base de datos usando C# y ASP.NET Core
---
## 🛠️ Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 
- Swagger
- SqlServer
---

## 📁 Estructura del proyecto
/Controllers
├── MandrilController.cs
├── SkillsController.cs
├── SkillsMandrilController.cs

/Models
├── Mandril.cs
├── MandrilDTO
├── Skill.cs
├── SkillDTO
├── PowerDTO.cs
├── Program

/Repositories
├── MandrilSkillsReadRepository
├── MandrilSkillsWriteRepository

/Interfaces
├── IMandrilSkillsReadRepository
├── IMandrilSkillsWriteRepository

/Service
├── MessageDefaultsDevs
├── MessageDefaultsUsers

/DatabaseContext
├── MandrilDbContext
├── MandrilWithSkillsIntermediateTable

/Middleware
├── ExceptionJsonMiddleware

/JsonFilterExeption
├── JsonFilter

# MandrilAPI

**MandrilAPI** es una API Web RESTful desarrollada en **C# con ASP.NET Core** que simula el manejo de una entidad `Mandril`, la cual puede estar asociada a un conjunto de habilidades (`Skills`). 

La aplicación está estructurada siguiendo principios de **arquitectura limpia** y **separación de responsabilidades**, lo que la hace ideal para aprender cómo escalar y organizar un proyecto de forma basica.

El sistema incluye tres controladores principales:
- `MandrilController`
- `SkillsController`
- `MandrilSkillsController`

Cada uno gestiona su respectiva tabla en una **base de datos SQL Server** por medio de EF, siendo `MandrilSkills` una tabla de relación **muchos a muchos**. La tabla MandrilSkills representa una relación muchos a muchos entre mandriles y habilidades, utilizando claves primarias compuestas. Además, incorpora una columna adicional llamada PowerMS(MS = MandrilSkill), que indica el nivel de habilidad asignado del 0 a maximo 4.

Esta tabla intermedia fue modelada manualmente con Entity Framework, lo cual permite un mayor control sobre su estructura y comportamiento, pensando en una posible escalabilidad futura del sistema y la incorporación de nuevas características.

---

## ¿Qué aporta este proyecto?
Este proyecto de práctica fue construido con el objetivo de ir más allá de lo básico. Se incluyen conceptos esenciales para el desarrollo backend profesional:

### Arquitectura y Diseño
- Implementación de **Arquitectura Limpia** (Clean Architecture)
- Estructura modular por capas bien definida
- Patrón Repository con separación de responsabilidades lectura/escritura
- Inyección de dependencias mediante interfaces

### Base de Datos
- Persistencia en SQL Server mediante Entity Framework Core
- Relación muchos a muchos entre `Mandril` y `Skills`
- Tabla intermedia `MandrilSkills` con campo `PowerMS` para nivel de habilidad
- Migraciones y configuración de entidades

### API RESTful
- Tres controladores principales:
  - `MandrilController`: Administracion de mandriles
  - `SkillsController`: Administración de habilidades
  - `MandrilSkillsController`: Manejo de relaciones mandril-habilidad
- Endpoints siguiendo convenciones REST
- Documentación con Swagger

### Calidad de Código
- Sistema de logging (ILogger) para monitoreo de operaciones desde consola
- Manejo de errores por capa con mensajes personalizados
- Validaciones de negocio
- DTOs para transferencia segura de datos
- Código limpio y documentado en inglés

## 🎯 Objetivos del Proyecto
Este proyecto está diseñado para demostrar:
1. Implementación de arquitectura escalable en .NET
2. Buenas prácticas en el desarrollo de APIs
3. Manejo de relaciones en base de datos
4. Patrones de diseño comunes en aplicaciones empresariales

## 🚀 Próximas Mejoras
- Sistema de autenticación/autorización basado en JWT y ASP.NET Identity.
- Desarrollo de interfaz de usuario en Angular

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
- Ilogger
---

## 📁 Estructura del proyecto
````
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
````


## 📚 Documentación con Swagger

Al iniciar el proyecto, Swagger se carga automáticamente en:  
https://localhost:(puerto)/swagger

Ahí podés ver y probar todos los endpoints disponibles.

## 🧪 Cómo ejecutar el proyecto

# Cómo ejecutar el proyecto en Windows

Este proyecto puede ejecutarse tanto desde línea de comandos como desde un IDE como Visual Studio o Rider.

## Opción 1: Desde línea de comandos (PowerShell o CMD)

1. **Clonar el repositorio:**
 ```
 git clone https://github.com/AdrianLeon09/mandrilapi 

 cd mandrilapi 
  ```

**3. Restaurar dependencias:**
 ```   
dotnet restore
 ```
**3. Aplicar migraciones para crear o actualizar la base de datos:**
 ```
dotnet ef database update
 ```
**4. Ejecutar la aplicación:**
   
dotnet run

**6. Abrir la documentación Swagger en tu navegador:**

 ```https://localhost:(puerto)/swagger/index.html ```


## Opción 2: Desde Visual Studio

Sigue estos pasos para abrir y ejecutar el proyecto en Visual Studio 2022:

1. **Abrir el proyecto o solución**  
   - Inicia Visual Studio 2022.  
   - Selecciona **Clona un repositorio**.  y coloca  ```https://github.com/AdrianLeon09/mandrilapi ```
   - 
     Si descargaste directamente el repositorio: 
     
   - Selecciona **Abrir proyecto/Solucion**.
   - Navega hasta la carpeta donde clonaste el repositorio y selecciona el archivo `MandrilAPi.sln` (solución) del proyecto.

2. **Restaurar dependencias**  
   - Visual Studio detectará automáticamente los paquetes NuGet necesarios y los restaurará.  
   - Puedes verificar el progreso en la ventana **Administrador de paquetes NuGet** o en la barra de estado.

3. **Configurar la cadena de conexión**  
   - Abre el archivo `appsettings.json` ubicado en el proyecto.  
   - Verifica que la cadena de conexión a la base de datos SQL Server esté correctamente configurada para tu entorno local.  
   - Ejemplo:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=mandrilDB;Trusted_Connection=true;TrustServerCertificate=True;"
   }

4. **Aplicar migraciones**
Abre la Consola del Administrador de Paquetes desde Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes.

Ejecuta el siguiente comando para crear o actualizar la base de datos:

 ```Update-Database ```

5. **Ejecutar la aplicación**
Presiona F5 para iniciar la aplicación en modo depuración, o Ctrl + F5 para ejecutarla sin depurar.
Se abrirá una ventana del navegador automáticamente con la documentacion de Swagger.

**(Opcional - Acceder a la documentación Swagger manualmente )**

En el navegador, accede a la URL: ``` http://localhost:(puerto)/swagger/index.html ```
Allí podrás ver la documentación interactiva de la API y probar los endpoints.

**NOTAS**
- Asegúrate de tener instalado Visual Studio 2022 con la carga de trabajo Desarrollo de ASP.NET y web.

- El puerto asignado puede variar; verifica el que aparece en la barra de direcciones del navegador cuando se inicia la aplicación.

- Si realizas cambios en las migraciones, recuerda aplicar nuevamente Update-Database para actualizar la base de datos.

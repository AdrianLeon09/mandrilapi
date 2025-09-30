
# MandrilAPI

**MandrilAPI** es una API Web RESTful desarrollada en **C# con ASP.NET Core (.NET 8)** que simula el manejo de una entidad `Mandril`, la cual puede estar asociada a un conjunto de habilidades (`Skills`). 

La aplicación sigue principios de **arquitectura limpia**, **separación de responsabilidades** y ahora incluye un sistema completo de **autenticación y autorización basada en JWT y ASP.NET Identity**.

---

## 🆕 Novedades y funcionalidades recientes

- **Sistema de autenticación y autorización JWT**: Registro, login y logout de usuarios, generación y validación de tokens JWT.
- **Gestión de usuarios**: Endpoints para obtener y actualizar datos del usuario autenticado (nombre, apellido, username público, email, fecha de nacimiento).
- **Roles y políticas**: Soporte para roles `Admin` y `User`, con endpoints protegidos por políticas y roles.
- **Controladores adicionales**:
  - `AccountController`: Registro, login y logout de usuarios.
  - `UserDataController`: Consulta y actualización de datos del usuario autenticado.
  - `AdminController`: Gestión avanzada de relaciones y usuarios (solo para administradores).
- **Validaciones avanzadas**: Validaciones personalizadas en DTOs para registro y actualización de usuarios.
- **Swagger con soporte para JWT**: Documentación interactiva y pruebas de endpoints autenticados.
- **Mensajes de error y éxito personalizados**: Mensajes claros y categorizados para cada operación.

---

## Arquitectura y Diseño

- **Arquitectura Limpia** (Clean Architecture)
- Estructura modular por capas bien definida
- Patrón Repository con separación de responsabilidades lectura/escritura
- Inyección de dependencias mediante interfaces
- **ASP.NET Identity** para gestión de usuarios y roles
- **JWT** para autenticación y autorización segura

## Base de Datos

- Persistencia en SQL Server mediante Entity Framework Core
- Relación muchos a muchos entre `Mandril` y `Skills` con tabla intermedia `MandrilSkills` y campo `PowerMS`
- Migraciones y configuración de entidades
- Tablas de usuarios y roles gestionadas por Identity

## API RESTful

- Controladores principales:
  - `MandrilController`: Administración de mandriles (solo Admin)
  - `SkillsController`: Administración de habilidades (solo Admin)
  - `MandrilSkillsController`: Manejo de relaciones mandril-habilidad (usuarios autenticados)
  - `AccountController`: Registro, login y logout de usuarios
  - `UserDataController`: Gestión de datos del usuario autenticado
  - `AdminController`: Gestión avanzada de relaciones y usuarios (solo Admin)
- Endpoints siguiendo convenciones REST
- Documentación con Swagger (incluye autenticación JWT)

## Calidad de Código

- Sistema de logging (ILogger) para monitoreo de operaciones
- Manejo de errores por capa con mensajes personalizados
- Validaciones de negocio y DTOs para transferencia segura de datos
- Código limpio y documentado

---

## 🎯 Objetivos del Proyecto

1. Implementación de arquitectura escalable en .NET
2. Buenas prácticas en el desarrollo de APIs seguras
3. Manejo de relaciones en base de datos y gestión de usuarios/roles
4. Patrones de diseño comunes en aplicaciones empresariales

---

## 🚀 Próximas Mejoras
- Pruebas automatizadas

---

## 🛠️ Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 
- ASP.NET Identity
- JWT (Json Web Token)
- Swagger
- SQL Server
- ILogger

---
---

## 📁 Estructura del proyecto
````
📁 MandrilAPI (Raíz del Proyecto)
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
````


## 📚 Documentación con Swagger

Al iniciar el proyecto, Swagger se carga automáticamente en:  
https://localhost:(puerto)/swagger

Ahí podés ver y probar todos los endpoints disponibles.

# 🧪 Cómo ejecutar el proyecto

## Cómo ejecutar el proyecto en Windows

Este proyecto puede ejecutarse tanto desde línea de comandos como desde un IDE como Visual Studio o Rider.

## Opción 1: Desde línea de comandos (PowerShell o CMD)

1. **Clonar el repositorio:**
 ```
 git clone https://github.com/AdrianLeon09/mandrilapi 

 cd mandrilapi 
  ```

**2. Restaurar dependencias:**
 ```   
dotnet restore
 ```
**3. Aplicar migraciones para crear la base de datos:**

**Configurar la cadena de conexión**  
   - Abre el archivo `appsettings.json` ubicado en el proyecto.  
   - Verifica que la cadena de conexión a la base de datos SQL Server esté correctamente configurada para tu entorno local.  
   - Ejemplo Windows:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=mandrilDB;Trusted_Connection=true;TrustServerCertificate=True;"
   }
```
- Ejemplo Linux:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=mandrilDB;UserId=sa;Password=TuPassword123;TrustServerCertificate=True;"
}

```

**4. Aplicar las migraciones correspondientes a **AuthDbCOntext** y **MandrilDbContext****

En la terminal vaya hasta la solucion del proyecto y escriba
```
dotnet ef migrations add NombreDeLaMigracion --context MandrilDbContext
```
```
dotnet ef migrations add NombreDeLaMigracion --context AuthDbContext
```
```
dotnet ef database update --context MandrilDbContext
```
```
dotnet ef database update --context AuthDbContext
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

**4. Aplicar las migraciones correspondientes a **AuthDbCOntext** y **MandrilDbContext****

Abre la Consola del Administrador de Paquetes desde Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes.

Ejecuta los siguientes comandos para crear las migraciones y actualizar la base de datos:

```
Add-Migration NombreDeLaMigracion -Context MandrilDbContext
```
```
Add-Migration NombreDeLaMigracion -Context AuthDbContext
```
 ```
 Update-Database -context MandrilDbCOntext
```
```
Update-Database -context AuthDbContext 
```

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

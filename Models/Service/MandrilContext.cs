using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Models.Service;

public  class MandrilContext : DbContext
{
    // Constructor del DbContext:
// Esta clase hereda de DbContext, que es la clase base de Entity Framework encargada de manejar la conexión y operaciones con la base de datos.

// Al constructor se le pasan las DbContextOptions<MandrilContext>, que contienen toda la configuración necesaria 
// (como el proveedor de base de datos, la cadena de conexión, etc.), y se reciben en el parámetro "options".

// Los dos puntos ":" indican que este constructor llama al constructor base de la clase DbContext 
// y le pasa esas opciones, permitiendo que EF Core configure internamente todo lo necesario para este contexto.

    public MandrilContext(DbContextOptions<MandrilContext> options) : base(options){
    }

//Representation of table mandril in the base data
public DbSet<Mandril> Mandrils { get; set; }

//Representation of table mandril in the base data
public DbSet<Habilidad> Habilidades { get; set; }


};
  
  

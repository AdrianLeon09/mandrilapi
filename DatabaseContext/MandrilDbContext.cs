using MandrilAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.DatabaseContext;

public  class MandrilDbContext : DbContext
{
    // Constructor del DbContext:
// Esta clase hereda de DbContext, que es la clase base de Entity Framework encargada de manejar la conexión y operaciones con la base de datos.

// Al constructor se le pasan las DbContextOptions<MandrilContext>, que contienen toda la configuración necesaria 
// (como el proveedor de base de datos, la cadena de conexión, etc.), y se reciben en el parámetro "options".

// Los dos puntos ":" indican que este constructor llama al constructor base de la clase DbContext 
// y le pasa esas opciones, permitiendo que EF Core configure internamente todo lo necesario para este contexto.

    public MandrilDbContext(DbContextOptions<MandrilDbContext> options) : base(options){
    }

//Representation of table mandril in the base data
public DbSet<Mandril> Mandrils { get; set; }

//Representation of table mandril in the base data
public DbSet<Skill> Skills { get; set; }
 public DbSet<MandrilWithSkillsIntermediateTable> MandrilWithSkills { get; set; }
 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
     modelBuilder.Entity<MandrilWithSkillsIntermediateTable>()
         .HasKey(mh => new { Mandrilid = mh.MandrilId, mh.SkillId });
     modelBuilder.Entity<MandrilWithSkillsIntermediateTable>().HasCheckConstraint("CK_MandrilPower_Power_Max4", "PowerMS <= 4");
 }


};
  
  

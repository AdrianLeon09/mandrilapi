using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Models.Service;

public  class MandrilContext : DbContext
{
    public MandrilContext(DbContextOptions<MandrilContext> options) : base(options){
    }


public DbSet<Mandril> Mandrils { get; set; }
public DbSet<Habilidad> Habilidades { get; set; }

// ya hice la implementacion ahora tengo que probar y entender mejor como va la cosa
};
  
  

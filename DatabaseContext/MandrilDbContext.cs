using MandrilAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.DatabaseContext;

public  class MandrilDbContext : DbContext
{
    public MandrilDbContext(DbContextOptions<MandrilDbContext> options) : base(options){ }
    
public DbSet<Mandril> Mandrils { get; set; }
public DbSet<Skill> Skills { get; set; }
 public DbSet<MandrilWithSkillsIntermediateTable> MandrilWithSkills { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MandrilWithSkillsIntermediateTable>().ToTable("MandrilWithSkills")
          .HasKey(mh => new {mh.MandrilId, mh.SkillId });

        modelBuilder.Entity<MandrilWithSkillsIntermediateTable>().ToTable("MandrilWithSkills", builder => builder.HasCheckConstraint("power_limit_4", "PowerMS <= 4"));
    }
};
  
  

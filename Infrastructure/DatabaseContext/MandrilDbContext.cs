using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace MandrilAPI.Infrastructure.DatabaseContext;

public  class MandrilDbContext : DbContext
{
    public MandrilDbContext(DbContextOptions<MandrilDbContext> options) : base(options){ }
    
public DbSet<Mandril> Mandrils { get; set; }
public DbSet<Skill> Skills { get; set; }
public DbSet<MandrilWithSkillsIntermediateTable> MandrilWithSkills { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MandrilWithSkillsIntermediateTable>().ToTable("MandrilWithSkills")
          .HasKey(mh => new {mh.MandrilId, mh.SkillId, mh.UserId });
        modelBuilder.Entity<MandrilWithSkillsIntermediateTable>().ToTable("MandrilWithSkills", builder => builder.HasCheckConstraint("power_limit_4", "PowerMS <= 4"));
      
        modelBuilder.Entity<Mandril>()
            .HasIndex(m => m.name)
            .IsUnique();
        
        modelBuilder.Entity<Mandril>()
            .HasIndex(m => m.lastName)
            .IsUnique();

        modelBuilder.Entity<Skill>()
            .HasIndex(s => s.name)
            .IsUnique();
    }
};
  
  

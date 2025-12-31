using System.ComponentModel.DataAnnotations.Schema;
using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using Microsoft.AspNetCore.Identity;

namespace MandrilAPI.Infrastructure.DatabaseContext;
public class MandrilWithSkillsIntermediateTable
{
   
    [ForeignKey(nameof(MandrilId))]
    public int MandrilId {get; set;}
    public Mandril Mandril { get; set; }
    public string UserId { get; set; }
    
    [NotMapped]
    public AuthDbContext User { get; set; }

    [ForeignKey(nameof(SkillId))]
    public int SkillId {get; set;}
    public  Skill Skill{get; set;}
    public int PowerMS { get; set; } = 0; // power default 0
    
}
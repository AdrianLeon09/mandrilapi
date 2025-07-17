using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MandrilAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.DatabaseContext;
public class MandrilWithSkillsIntermediateTable
{
   
    [ForeignKey(nameof(MandrilId))]
    public int MandrilId {get; set;}
    public   Mandril Mandril { get; set; }
    

    [ForeignKey(nameof(SkillId))]
    public int SkillId {get; set;}
    public  Skill Skill{get; set;}

    public int PowerMS { get; set; } = 0; // power default 0
    
}
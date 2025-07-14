using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MandrilAPI.Models;

public class SkillDTO
{
    [Required(ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    [MaxLength(25, ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    
    public string name { get; set; }
}
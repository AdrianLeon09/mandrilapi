using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MandrilAPI.Models;

public class SkillDTO
{
    [Required]
    [MinLength(3, ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    [MaxLength(25)]
    public string name { get; set; }
}
using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MandrilAPI.Models;

public class SkillDTO
{
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MaxLength(25, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    
    public string name { get; set; }
}
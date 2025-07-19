using System.ComponentModel.DataAnnotations;
using MandrilAPI.Aplication.Service;

namespace MandrilAPI.Infrastructure.DTOs;

public class SkillDto
{
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MaxLength(25, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    
    public string name { get; set; }
}
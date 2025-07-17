using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;


namespace MandrilAPI.Models;

public class SkillDto
{
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MaxLength(25, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    
    public string name { get; set; }
}
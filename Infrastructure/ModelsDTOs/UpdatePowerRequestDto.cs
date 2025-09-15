using System.ComponentModel.DataAnnotations;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.CustomAnnotations;

namespace MandrilAPI.Infrastructure.ModelsDTOs;

public class UpdatePowerRequestDto
{
    
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
    [OnlyLetterCount(3)]
    public string PublicUserName { get; set; }
    
    [Required(ErrorMessage = "Error: Letters and special characters are not allowed.")]
    [Range(0,4, ErrorMessage = MessageDefaultsUsers.PowerInvalid) ]
    public int Power { get; set; }
    
   
    
}
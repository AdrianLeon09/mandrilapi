using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.DTOs;

public class MandrilDto
{ 
    
[Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
   
    [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    public string name { get; set; } = String.Empty;

  
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    
    [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]

    public string lastName { get; set; } = string.Empty;
}
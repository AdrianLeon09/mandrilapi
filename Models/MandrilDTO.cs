using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Models;

public class MandrilDTO
{ 
        
        
   
[Required(ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
   
    [StringLength(25, ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    public string name { get; set; } = String.Empty;

  
    [Required(ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    
    [StringLength(25, ErrorMessage = DefaultsMessageUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = DefaultsMessageUsers.EntryInvalid)]

    public string lastName { get; set; } = string.Empty;
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.CustomAnnotations;

namespace MandrilAPI.Infrastructure.DTOs;

public class RegisterUserDto

{
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]   
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
    [OnlyLetterCount(3)]
    public string PublicUserName { get; set; }

    
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
    [OnlyLetterCount(3)]
    public string FirsName { get; set; }
    
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
    [OnlyLetterCount(3)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
   [EmailAddress(ErrorMessage = MessageDefaultsUsers.EmailInvalid)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    public string Password { get; set; }
    
    [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
    [Compare("Password", ErrorMessage = MessageDefaultsUsers.PasswordMismatch)]
    public string ConfirmPassword { get; set;}
    
    public DateTime DateOfBirth { get; set; }
}
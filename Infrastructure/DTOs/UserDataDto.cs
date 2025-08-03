using MandrilAPI.Aplication.Service;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Infrastructure.DTOs
{
    public class UserDataDto
    {
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryLength)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = MessageDefaultsUsers.EntryLength)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryLength)]
        public string LastName { get; set; }


        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryLength)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress(ErrorMessage = "The Email address invalid")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "DateOfBirthDay required")]
        public DateTime DateOfBirth { get; set; } = new DateTime();
    }

    public class UserFirstNameDto
    {
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryLength)]
        public string FirstName { get; set; }


    }

    public class UserLastNameDto
    {
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryLength)]
        public string LastName { get; set; }
    }

    public class UserEmailDto
    {
        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress(ErrorMessage = "The Email address invalid")]
        public string UserEmail { get; set; }
    }
    public class UserDateOfBirthDto
    {
        [Required(ErrorMessage = "DateOfBirthDay required")]
        public DateTime DateOfBirth { get; set; } = new DateTime();
    }
}

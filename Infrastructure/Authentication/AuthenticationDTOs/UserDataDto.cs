using MandrilAPI.Aplication.Service;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.CustomAnnotations;

namespace MandrilAPI.Infrastructure.DTOs
{
    public class UserDataDto
    {
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        public string FirstName { get; set; }

        
        [Required(ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        public string PublicUserName { get; set; }
        
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
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        public string FirstName { get; set; } 
        
    }

    public class UserLastNameDto
    {
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        
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

    public class PublicUserNameDto
    {
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        
        public string PublicUserName { get; set; }
    }

    public class AllUsersDto
    {
        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]

        public string FirstName { get; set; }
        

        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        
        public string LastName { get; set; }

        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [MinLength(3, ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [StringLength(25, ErrorMessage = MessageDefaultsUsers.EntryMaxLength)]
        [OnlyLetterCount(3)]
        
        public string PublicUserName { get; set; }

        [Required(ErrorMessage = MessageDefaultsUsers.EntryInvalid)]
        [EmailAddress]
         public string Email { get; set; }
        
        
        public int NumberOfMandrils { get; set; }
        
        public DateTime  CreateAt { get; set; }
    }

    public class UserRelationshipsDto
    {
      public string PublicUserName {get; set;}
        public List<RelationMandrilSkillsDto> Mandril{ get; set; } = new List<RelationMandrilSkillsDto>();
    }

    public class RelationMandrilSkillsDto
    {
        public int Id { get; set; }
        public string mandrilName { get; set; }
        
        public List<SkillRelationDto> Skills { get; set; } = new List<SkillRelationDto>();
        
    }

    public class SkillRelationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}

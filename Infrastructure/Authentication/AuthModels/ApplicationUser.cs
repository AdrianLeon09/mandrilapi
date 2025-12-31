using MandrilAPI.Aplication.Service;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Infrastructure.Authentication.AuthModels
{
    public class ApplicationUser() : IdentityUser
    {
       
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PublicUserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

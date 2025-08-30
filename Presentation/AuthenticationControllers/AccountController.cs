using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MandrilAPI.Presentation.AuthControllers;

[ApiController]
[Route("api/[controller]/")]
public class AccountController(
  UserManager<ApplicationUser> usermanager,
  RoleManager<IdentityRole> rolemanager,
  SignInManager<ApplicationUser> signinmanager)
  : Controller
{
  private readonly UserManager<ApplicationUser> _userM = usermanager;
  private readonly SignInManager<ApplicationUser> _signInM = signinmanager;
  private readonly RoleManager<IdentityRole> _roleM = rolemanager;

  [HttpPost("Register/")]
  public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
  {
   
    var user = new ApplicationUser()
    {
      FirstName = registerDto.FirsName, LastName = registerDto.LastName, UserName = registerDto.Email,
      PublicUserName = registerDto.PublicUserName, Email = registerDto.Email, DateOfBirth = registerDto.DateOfBirth
      
    };

      if (registerDto.Password.Length < 6)
      {
        return BadRequest(MessageDefaultsUsers.PasswordTooShort);
      }
      else
      {

        await _userM.CreateAsync(user, registerDto.Password);
        await _userM.AddToRoleAsync(user, "User");
        await _userM.UpdateAsync(user);

        return Ok(MessageDefaultsUsers.RegistrationSucceeded);
        
        
      }
    
  }
  
  [HttpPost("Login/")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
     
      var user = await _userM.FindByEmailAsync(loginDto.Email);
      var checkPassword = await _userM.CheckPasswordAsync(user, loginDto.Password);
      if (user is null || checkPassword == false)
      {
        return Unauthorized();
      }
      else
      {
        await _signInM.SignInAsync(user, true);
        return Ok("Login Successful");
      }

    }

    
  
  
}
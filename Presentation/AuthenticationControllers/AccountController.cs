using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.Authentication;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;

namespace MandrilAPI.Presentation.AuthControllers;

[ApiController]
[Route("api/[controller]/")]
public class AccountController(
  UserManager<ApplicationUser> usermanager,
  RoleManager<IdentityRole> rolemanager,
  SignInManager<ApplicationUser> signinmanager,
  GenerateJwt generateJwt, Functions functions)
  : Controller
{
  private readonly UserManager<ApplicationUser> _userM = usermanager;
  private readonly SignInManager<ApplicationUser> _signInM = signinmanager;
  private readonly RoleManager<IdentityRole> _roleM = rolemanager;
  private readonly GenerateJwt _jwt = generateJwt;
  private readonly Functions _functions = functions;

    [HttpPost("register/")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
    {

        var user = new ApplicationUser()
        {
            FirstName = registerDto.FirsName, LastName = registerDto.LastName, UserName = registerDto.Email,
            PublicUserName = registerDto.PublicUserName, Email = registerDto.Email, DateOfBirth = registerDto.DateOfBirth
        };

        bool checkPublicUserN = await _functions.CheckIfPublicUsernameExists(registerDto.PublicUserName);
        bool checkEmail = await _functions.CheckIfEmailExists(registerDto.Email);

        if (checkPublicUserN)
        {

            return Conflict(MessageDefaultsUsers.PublicUsernameAlreadyExist);
        }
        else
        {

            if (checkEmail)
            {
              return  Conflict(MessageDefaultsUsers.EmailAlreadyExist);
            }
            else
            {

                await _userM.CreateAsync(user, registerDto.Password);
                await _userM.AddToRoleAsync(user, "User");
                await _userM.UpdateAsync(user);

                return Ok(MessageDefaultsUsers.RegistrationSucceeded);

            }
        
        }
        
    }
    
    [HttpPost("login/")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {

        var user = await _userM.FindByEmailAsync(loginDto.Email);


        if (user is null)
        {

            return NotFound(MessageDefaultsUsers.UserNotFound);

        }
        else
        {
            var checkPassword = await _userM.CheckPasswordAsync(user, loginDto.Password);

            if (checkPassword == false)
            {
                return Unauthorized(MessageDefaultsUsers.PasswordWrong);
            }
            else
            {
                
                var token = await _jwt.Token(user);
                
                return Ok(token);
            }

        }
    }

    [HttpPost("logout/")]
    public async Task<IActionResult> Logout()
    {
        await _signInM.SignOutAsync();
        
        return Ok("logout success");
    }
    
}
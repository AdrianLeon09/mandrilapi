using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MandrilAPI.Aplication.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using static Microsoft.AspNetCore.Identity.IdentityConstants;

namespace MandrilAPI.Presentation.AuthenticationControllers;

[ApiController]
[Route("api/[controller]/")]


[Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
    Roles = "Admin,User")]

public class UserDataController(UserManager<ApplicationUser> userM, Functions functions) : Controller
{
    private readonly UserManager<ApplicationUser> _userM = userM;
    private readonly Functions _fuctions = functions;
   
  
    [HttpGet("get-userdata/")]
    public async Task<IActionResult> GetUserData()
    {
        var user = await _userM.GetUserAsync(User);

        if (user is null)
        {
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }else
        {
         var userDto = new UserDataDto();
            userDto.PublicUserName = user.PublicUserName ?? string.Empty;
            userDto.FirstName = user.FirstName ?? string.Empty;
            userDto.LastName = user.LastName ?? string.Empty;
            userDto.PublicUserName = user.PublicUserName ?? string.Empty;
            userDto.UserEmail = user.Email ?? string.Empty;
            userDto.DateOfBirth = user.DateOfBirth;
         return Ok(userDto);
        }
    }
    
    [HttpPatch("update-FirstName/")]
    public async Task<IActionResult> UpdateFirstName([FromBody]UserFirstNameDto newFirstName)
    {
        var user = await _userM.GetUserAsync(User);
        
        if(user is null)
        { 
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }else {
            user.FirstName = newFirstName.FirstName;
            await _userM.UpdateAsync(user);
            return Ok(MessageDefaultsUsers.FirstNameUpdateSucceeded);
        }
    }


    [HttpPatch("update-lastname/")]
   
    public async Task<IActionResult> UpdateLastName([FromBody]UserLastNameDto newLastName)
    {
        var user = await _userM.GetUserAsync(User);
        if (user is null) {
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }else { 
            user.LastName = newLastName.LastName;
            await _userM.UpdateAsync(user);
            return Ok(MessageDefaultsUsers.LastNameUpdateSucceeded);
        }
    }

    [HttpPatch("update-publicusername/")]
    public async Task<IActionResult> UpdateUserName([FromBody] PublicUserNameDto newPublicUserName)
    {
        var user = await _userM.GetUserAsync(User);

        if (user is null) {
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }
        else
        {
            var checkUsername = await _fuctions.IsPublicUsernameAvailableForUpdate(user, newPublicUserName.PublicUserName);

            if (checkUsername) {
                return Conflict(MessageDefaultsUsers.PublicUsernameAlreadyExist);
            }else
            {
                user.PublicUserName = newPublicUserName.PublicUserName;
                await _userM.UpdateAsync(user);
                return Ok(MessageDefaultsUsers.PublicUserNameUpdateSucceeded);
            }
        }
    }
}





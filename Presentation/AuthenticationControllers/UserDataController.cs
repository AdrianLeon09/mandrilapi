using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MandrilAPI.Aplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace MandrilAPI.Presentation.AuthControllers;

[ApiController]
[Route("api/[controller]/")]


public class UserDataController(UserManager<ApplicationUser> userM) : Controller
{
    private readonly UserManager<ApplicationUser> _userM = userM;



    [HttpGet("GetUserData/")]
    public async Task<IActionResult> GetUserData()
    {
        var user = await _userM.GetUserAsync(User);

        var userDto = new UserDataDto();
        userDto.FirstName = user.FirstName;
        userDto.LastName = user.LastName;
        userDto.PublicUserName = user.PublicUserName;
        userDto.UserEmail = user.Email;
        userDto.DateOfBirth = user.DateOfBirth;


        return Ok(userDto);
    }
    //hacer que el usurio creado se agrege automamticamente al rol users
    [HttpPatch("UpdateFirstName/")]
    [Authorize(Roles = "User", Policy = "UserOnly")]
    public async Task<IActionResult> UpdateFirstName([FromBody]UserFirstNameDto newFirstName)
    {
        var user = await _userM.GetUserAsync(User);
        
        user.FirstName = newFirstName.FirstName;

        await _userM.UpdateAsync(user);

        return Ok(MessageDefaultsUsers.FirstNameUpdateSucceeded);
     
    }


    [HttpPatch("UpdateLastName/")]
    public async Task<IActionResult> UpdateLastName([FromBody]UserLastNameDto newLastName)
    {
        var user = await _userM.GetUserAsync(User);

        user.LastName = newLastName.LastName;

        await _userM.UpdateAsync(user);

        return Ok(MessageDefaultsUsers.LastNameUpdateSucceeded);

    }

    [HttpPatch("UpdatePublicUserName/")]
    public async Task<IActionResult> UpdateUserName([FromBody] PublicUserNameDto newPublicUserName)
    {
        var user = await _userM.GetUserAsync(User);
        var checkUsername = _userM.Users.FirstOrDefault(u=> u.PublicUserName == newPublicUserName.PublicUserName && u.Id != user.Id);
       
        if (checkUsername is not null) 
        {
            return BadRequest(MessageDefaultsUsers.PublicUsernameAlreadyExists);
        }
        else
        {
             user.PublicUserName = newPublicUserName.PublicUserName;
                    
                    await _userM.UpdateAsync(user);
                    
                    return Ok(MessageDefaultsUsers.PublicUserNameUpdateSucceeded);
            
        }
       
    }
}





using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        userDto.UserName = user.UserName;
        userDto.UserEmail = user.Email;
        userDto.DateOfBirth = user.DateOfBirth;


        return Ok(userDto);
    }
    [HttpPatch("UpdateFirstName/")]
    public async Task<IActionResult> UpdateFirstName([FromBody]UserFirstNameDto newFirstName)
    {
        var user = await _userM.GetUserAsync(User);

        user.FirstName = newFirstName.FirstName;

        await _userM.UpdateAsync(user);

        return Ok("success");
     
    }


    [HttpPatch("UpdateLastName/")]
    public async Task<IActionResult> UpdateLastName([FromBody] String newLastName)
    {
        var user = await _userM.GetUserAsync(User);

        user.LastName = newLastName;

        await _userM.UpdateAsync(user);

        return Ok("success");

    }
}





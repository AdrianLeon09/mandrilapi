using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;

namespace MandrilAPI.Infrastructure.Authentication;

public class GenerateJwt( IConfiguration config, UserManager<ApplicationUser> userM)
{
    private readonly IConfiguration _config = config;
    private readonly UserManager<ApplicationUser> _userManager = userM;
    
    public  async Task<string> Token(ApplicationUser user)
    {
        List<Claim> roleslist = new();
        
        var roleUser = await _userManager.GetRolesAsync(user);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["JwtSettings:Issuer"],
            audience: _config["JwtSettings:Audience"],
            claims: new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
            }.Union(roleUser.Select(x => new Claim(ClaimTypes.Role, x))),
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtSettings:DurationInMinutes"])),
            signingCredentials: creds

            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    
    
}

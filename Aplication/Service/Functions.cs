using MandrilAPI.Infrastructure.Authentication.AuthModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Aplication.Service
{
    public class Functions(UserManager<ApplicationUser> userm, ILogger<Functions> logger
        )
    {
        UserManager<ApplicationUser> _userM = userm;
        ILogger<Functions> _logger = logger;

        public async Task<bool> CheckIfPublicUsernameExists(string PublicUsername)
        {
            if (await _userM.Users.AnyAsync(u => u.PublicUserName == PublicUsername))
            {
                _logger.LogInformation(MessageDefaultsDevs.PublicUsernameAlreadyExists);
                return true;

            } else { 
                _logger.LogInformation(MessageDefaultsDevs.CheckPublicUsernamePassed);

                return false; }
        }

        public async Task<bool> IsPublicUsernameAvailableForUpdate(ApplicationUser user ,string newPublicUsername)
        {
            

            if (await _userM.Users.AnyAsync(u => u.PublicUserName == newPublicUsername ))
            {
                _logger.LogInformation(MessageDefaultsDevs.PublicUsernameAlreadyExists);
                return true;

            }
            else
            {
                _logger.LogInformation(MessageDefaultsDevs.CheckPublicUsernamePassed);

                return false;
            }
        }


        public async Task<bool> CheckIfEmailExists(string email)
        {
            if (await _userM.Users.AnyAsync(u => u.Email == email))
            {
                _logger.LogInformation(MessageDefaultsDevs.EmailAlreadyExists);
                return true;

            }
            else {
                _logger.LogInformation(MessageDefaultsDevs.CheckEmailPassed);
                
                return false; }
        }
    }
}

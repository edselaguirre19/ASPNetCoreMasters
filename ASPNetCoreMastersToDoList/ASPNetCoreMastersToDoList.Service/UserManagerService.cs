using ASPNetCoreMastersToDoList.Service.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreMastersToDoList.Service
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserManagerService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPassWordAsync(IdentityUser user, string password)
            => await _userManager.CheckPasswordAsync(user, password);

        public async Task<IdentityResult> ConfirmEmailAsync(IdentityUser user, string code)
            => await _userManager.ConfirmEmailAsync(user, code);

        public async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password)
            => await _userManager.CreateAsync(user, password);

        public async Task<IdentityUser> FindByEmailAsync(string email)
            => await _userManager.FindByEmailAsync(email);

        public async Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser user)
            => await _userManager.GenerateEmailConfirmationTokenAsync(user);



    }
}

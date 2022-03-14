using ASPNetCoreMastersToDoList.Service.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreMastersToDoList.Service
{
    public interface IUserManagerService
    {
        Task<IdentityResult> CreateUserAsync(IdentityUser user, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser user);

        Task<IdentityUser> FindByEmailAsync(string email);

        Task<IdentityResult> ConfirmEmailAsync(IdentityUser user, string code);

        Task<bool> CheckPassWordAsync(IdentityUser user, string password);
    }
}

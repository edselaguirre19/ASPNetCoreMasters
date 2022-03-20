using ASPNetCoreMastersToDoList.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ASPNetCoreMastersToDoList.API.Authorization
{
    public class CanEditItemRequirement : IAuthorizationRequirement
    {
    }

    public class CanEditItemHandler : AuthorizationHandler<CanEditItemRequirement, Item>
    {
        private readonly UserManager<IdentityUser> _userManager;
        public CanEditItemHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanEditItemRequirement requirement, Item resource)
        {
            var currentUser = await _userManager.GetUserAsync(context.User);
            if (currentUser == null)
            {
                return;
            }

            if(resource.CreatedBy == currentUser.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
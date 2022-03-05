using ASPNetCoreMastersToDoList.API.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASPNetCoreMastersToDoList.API.Controllers
{
    public class UsersController : ControllerBase
    {
        private Authentication _authenticationSettings;

        public UsersController(IOptions<Authentication> authenticationSettings)
        {
            _authenticationSettings = authenticationSettings.Value;
        }

        [HttpGet("Users")]
        public IActionResult Login()
        {           
            return Ok(this._authenticationSettings);
        }
    }
}

using ASPNetCoreMastersToDoList.API.BindingModels;
using ASPNetCoreMastersToDoList.Data;
using ASPNetCoreMastersToDoList.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPNetCoreMastersToDoList.API.Controllers
{
    public class UsersController : ControllerBase
    {

        private readonly IUserManagerService _userManagerService;
        private readonly JwtOptions _options;

        public UsersController(
            IUserManagerService userManagerService,
            IOptions<JwtOptions> options)
        {
            _userManagerService = userManagerService;
            _options = options.Value;
        }

        [HttpPost("Users/Login")]
        public async Task<IActionResult> Login(LoginBindingModel loginBindingModel)
        {
            IActionResult actionResult;
            var user = await _userManagerService.FindByEmailAsync(loginBindingModel.Email);
            if (user == null)
            {
                actionResult = NotFound(new { error = new[] { $"Email {loginBindingModel.Email} not found" } });
            }
            else if (await _userManagerService.CheckPassWordAsync(user, loginBindingModel.Password))
            {
                if (!user.EmailConfirmed)
                {
                    actionResult = NotFound(new { error = new[] { $"Email {loginBindingModel.Email} not confirmed" } });
                }
                else
                {
                    var token = GenerateToken(user);
                    actionResult = Ok(token);
                }
            }
            else
            {
                actionResult = NotFound(new { error = new[] { $"Invalid password" } });
            }
            return actionResult;
        }

        [HttpGet("Users/Register")]
        public async Task<IActionResult> Register(RegisterBindingModel registerBindingModel)
        {
            //return Ok(this._authenticationSettings);
            var user = new IdentityUser
            {
                Email = registerBindingModel.Email,
                UserName = registerBindingModel.Email
            };

            var result = await _userManagerService.CreateUserAsync(user, registerBindingModel.Password);
            if (result.Succeeded)
            {
                var code = await _userManagerService.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                return Ok(new { code = code, email = registerBindingModel.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("Users/Confirm")]
        public async Task<IActionResult> ConfirmEmail(ConfirmingBindingModel confirmingBindingModel)
        {
            var user = await _userManagerService.FindByEmailAsync(confirmingBindingModel.Email);
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmingBindingModel.Code));

            if (user == null || user.EmailConfirmed)
            {
                return BadRequest();
            }
            else if ((await _userManagerService.ConfirmEmailAsync(user, code)).Succeeded)
            {
                return Ok("Your email is confirmed!");
            }
            else
            {
                return BadRequest();
            }
        }


        #region private methods

        private string GenerateToken(IdentityUser user)
        {
            IList<Claim> userClaims = new List<Claim>()
            {
                new Claim("UserName", user.Email),
                new Claim("Email", user.Email)
            };
            return new JwtSecurityTokenHandler()
                .WriteToken(new JwtSecurityToken(
                    claims: userClaims,
                    expires: DateTime.UtcNow.AddMonths(1),
                    signingCredentials: new SigningCredentials(_options.SecurityKey, SecurityAlgorithms.HmacSha256
                    )));
        }

        #endregion
    }
}

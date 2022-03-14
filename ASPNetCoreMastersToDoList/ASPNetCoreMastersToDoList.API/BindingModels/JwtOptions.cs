using Microsoft.IdentityModel.Tokens;

namespace ASPNetCoreMastersToDoList.API.BindingModels
{
    public class JwtOptions
    {
        public SecurityKey SecurityKey { get; set; }
      
    }
}

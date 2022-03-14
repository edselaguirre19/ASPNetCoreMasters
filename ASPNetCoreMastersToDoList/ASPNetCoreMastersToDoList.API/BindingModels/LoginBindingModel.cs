using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.API.BindingModels
{
    public class LoginBindingModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    
    }
}

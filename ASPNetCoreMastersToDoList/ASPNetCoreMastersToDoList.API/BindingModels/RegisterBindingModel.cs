using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.API.BindingModels
{
    public class RegisterBindingModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}

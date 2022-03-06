﻿using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.API.BindingModels
{
    public class ConfirmingBindingModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Code { get; set; }
    }
}

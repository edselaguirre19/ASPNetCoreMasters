

using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersToDoList.API.BindingModels
{
    public class ItemCreateBindingModel
    {
        [StringLength(128, MinimumLength = 1)]
        public string? Text { get; set; }
    }
}

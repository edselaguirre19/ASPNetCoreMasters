using Microsoft.AspNetCore.Mvc;
using ASPNetCoreMastersToDoList.Service;
using ASPNetCoreMastersToDoList.API.BindingModels;
using ASPNetCoreMastersToDoList.Service.DTO;

namespace ASPNetCoreMastersToDoList.API.Controllers
{
    public class ItemsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemsService _itemsService;

        public ItemsController(
            ILogger<ItemsController> logger,
            IItemsService itemService)
        {
            _logger = logger;
            _itemsService = itemService;
        }

        public int Get(int id)
        {
            _logger.LogInformation("Entering controller...");
            return _itemsService.GetItems(id);
        }

        [HttpPost]
        public IActionResult Post(ItemCreateBindingModel itemCreateBindingModel)
        {
            _logger.LogInformation("Entering controller...");
            var itemCreateBindingModelDTO = MapItemCreateBindingModelToDTO(itemCreateBindingModel);
            _itemsService.SaveItems(itemCreateBindingModelDTO);
            return Ok();
        }


        #region Private Methods
        private ItemCreateBindingModelDTO MapItemCreateBindingModelToDTO(ItemCreateBindingModel itemCreateBindingModel)
            => new ItemCreateBindingModelDTO() { Text = itemCreateBindingModel.Text };
        #endregion

    }
}

using Microsoft.AspNetCore.Mvc;
using ASPNetCoreMastersToDoList.Service;
using ASPNetCoreMastersToDoList.API.BindingModels;
using ASPNetCoreMastersToDoList.Service.DTO;
using ASPNetCoreMastersToDoList.API.Filters;
using Microsoft.AspNetCore.Authorization;

namespace ASPNetCoreMastersToDoList.API.Controllers
{
    [Authorize]
    [TypeFilter(typeof(ValidationRequestFilter))]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemService _itemsService;

        public ItemsController(
            ILogger<ItemsController> logger,
            IItemService itemService)
        {
            _logger = logger;
            _itemsService = itemService;
        }

        [HttpGet("items")]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Entering controller...");
            return Ok(_itemsService.GetAll());
        }

        [HttpGet("items/{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Entering controller...");
            return Ok(_itemsService.GetItem(id));
        }

        [HttpGet("items/filterby")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            _logger.LogInformation("Entering controller...");
            return Ok(_itemsService.GetFilteredItems(filters));
        }

        [HttpPost("items")]
        public IActionResult Post(ItemCreateBindingModel itemCreateBindingModel)
        {
            _logger.LogInformation("Entering controller...");
            var itemCreateBindingModelDTO = MapItemCreateBindingModelToDTO(itemCreateBindingModel);
            return Ok(_itemsService.SaveItems(itemCreateBindingModelDTO));
        }

        [HttpPut("items/{id}")]
        public IActionResult Put(int id,
            [FromBody] ItemCreateBindingModel itemCreateBindingModel)
        {
            _logger.LogInformation("Entering controller...");
            var itemCreateBindingModelDTO = MapItemCreateBindingModelToDTO(itemCreateBindingModel);
            return Ok(_itemsService.UpdateItem(id, itemCreateBindingModelDTO));
        }

        [HttpDelete("items/{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Entering controller...");
            return Ok(_itemsService.DeleteItem(id));
        }


        #region Private Methods
        private ItemDTO MapItemCreateBindingModelToDTO(ItemCreateBindingModel itemCreateBindingModel)
            => new ItemDTO() { Text = itemCreateBindingModel.Text };
        #endregion

    }
}

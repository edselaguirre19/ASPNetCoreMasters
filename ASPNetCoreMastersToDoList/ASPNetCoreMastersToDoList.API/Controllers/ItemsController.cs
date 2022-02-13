using Microsoft.AspNetCore.Mvc;
using ASPNetCoreMastersToDoList.Service;

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

        [HttpGet("/")]
        public IEnumerable<string> Get(int id)
        {
            _logger.LogInformation("Entering controller...");
            return _itemsService.GetItems(id);
        }

    }
}

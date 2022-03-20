using Microsoft.AspNetCore.Mvc;
using ASPNetCoreMastersToDoList.Service;
using ASPNetCoreMastersToDoList.API.BindingModels;
using ASPNetCoreMastersToDoList.Service.DTO;
using ASPNetCoreMastersToDoList.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ASPNetCoreMastersToDoList.Data.Model;

namespace ASPNetCoreMastersToDoList.API.Controllers
{
    [Authorize]
    [TypeFilter(typeof(ValidationRequestFilter))]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemService _itemsService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAuthorizationService _authService;

        public ItemsController(
            ILogger<ItemsController> logger,
            IItemService itemService,
            IAuthorizationService authService,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _itemsService = itemService;
            _authService = authService;
            _userManager = userManager;
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
        public async Task<IActionResult> Put(int id,
            [FromBody] ItemCreateBindingModel itemCreateBindingModel)
        {
            _logger.LogInformation("Entering controller...");
            var item = _itemsService.GetItem(id);
            var canEditItem = await _authService.AuthorizeAsync(User, new Item() { CreatedBy = item.CreatedBy }, "CanEditItem");
            if (!canEditItem.Succeeded)
            {
                return new ForbidResult();
            }
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

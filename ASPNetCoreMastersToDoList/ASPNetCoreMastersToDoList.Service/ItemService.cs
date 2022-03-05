using ASPNetCoreMastersToDoList.Repository;
using ASPNetCoreMastersToDoList.Service.DTO;
using DomainModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreMastersToDoList.Service
{
    public class ItemService : IItemService
    {
        private readonly ILogger<ItemService> _logger;
        private readonly IItemRepository _itemRepository;
        public ItemService(
            ILogger<ItemService> logger,
            IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        public string DeleteItem(int id)
        {
            _logger.LogInformation("Entering service...");
            _itemRepository.Delete(id);
            return $"Item {id} deleted!";
        }

        public IEnumerable<Item> GetAll()
        {
            _logger.LogInformation("Entering service...");
            return _itemRepository.GetAll();
        }

        public IEnumerable<Item> GetFilteredItems(Dictionary<string, string> filters)
        {
            _logger.LogInformation("Entering service...");
            var filter = new ItemByFilterDTO { Filter = filters };
            return _itemRepository.GetAllByFilter(filter);
        }

        public Item GetItem(int id)
        {
            _logger.LogInformation("Entering service...");
            return _itemRepository.Get(id);
        }

        public string SaveItems(ItemDTO itemDTO)
        {
            _logger.LogInformation("Entering service...");
            var item = new Item
            {
                Id = itemDTO.Id,
                Text = itemDTO.Text,
            };
            _itemRepository.Add(item);
            return "Items Saved!";
        }

        public string UpdateItem(int id, ItemDTO itemDTO)
        {
            var item = new Item
            {
                Id = itemDTO.Id,
                Text = itemDTO.Text,
            };
            _itemRepository.Update(item);
            return $"Item {id} updated!";
        }
    }
}

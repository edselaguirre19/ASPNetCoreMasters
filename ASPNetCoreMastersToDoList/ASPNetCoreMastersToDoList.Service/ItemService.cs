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
    public class ItemService : IItemsService
    {
        private readonly ILogger<ItemService> _logger;
        public ItemService(ILogger<ItemService> logger)
        {
            _logger = logger;
        }

        public string DeleteItem(int id)
        {
            _logger.LogInformation("Entering service...");
            return $"Item {id} deleted!";
        }

        public string GetAll()
        {
            _logger.LogInformation("Entering service...");
            return "Items retrieved!";
        }

        public string GetFilteredItems(Dictionary<string, string> filters)
        {
            _logger.LogInformation("Entering service...");
            return "Filtered items retrived!";
        }

        public string GetItem(int id)
        {
            _logger.LogInformation("Entering service...");           
            return $"Item {id} retrieved!";
        }

        public string SaveItems(ItemCreateBindingModelDTO itemsCreateBindingModelDTO)
        {
            _logger.LogInformation("Entering service...");
            return "Items Saved!";
        }

        public string UpdateItem(int id, ItemCreateBindingModelDTO itemCreateBindingModelDTO)
        {
            return $"Item {id} updated!";
        }
    }
}

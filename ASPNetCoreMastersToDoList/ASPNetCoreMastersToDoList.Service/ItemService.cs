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

        public int GetItems(int userId)
        {
            _logger.LogInformation("Entering service...");           
            return userId;
        }

        public void SaveItems(ItemCreateBindingModelDTO itemsCreateBindingModelDTO)
        {
            new ItemDomainModel
            {
                Text = itemsCreateBindingModelDTO.Text,
            };
        }
    }
}

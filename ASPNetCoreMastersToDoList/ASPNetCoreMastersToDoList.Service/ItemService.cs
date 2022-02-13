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

        public IEnumerable<string> GetItems(int userId)
        {
            _logger.LogInformation("Entering service...");
            var result = new List<string>();
            result.Add(userId.ToString());
            return result;
        }
    }
}

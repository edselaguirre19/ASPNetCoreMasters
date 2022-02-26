using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreMastersToDoList.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetAllByFilter(ItemByFilterDTO filters);
        Item Get(int itemId);
        void Add(Item item);
        void Update(Item item);
        void Delete(int id);
    }
}

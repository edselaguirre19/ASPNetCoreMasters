using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreMastersToDoList.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;
        public ItemRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void Add(Item item)
        {
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
        }

        public Item Get(int itemId)
        {
            return new Item();
        }

        public IEnumerable<Item> GetAll()
        {
           return Enumerable.Empty<Item>();
        }

        public IEnumerable<Item> GetAllByFilter(ItemByFilterDTO filters)
        {
            return _dataContext.Items;
        }

        public void Update(Item item)
        {
           // throw new NotImplementedException();
        }
    }
}

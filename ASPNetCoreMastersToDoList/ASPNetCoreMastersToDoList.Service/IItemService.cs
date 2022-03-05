using ASPNetCoreMastersToDoList.Service.DTO;
using DomainModels;

namespace ASPNetCoreMastersToDoList.Service
{
    public interface IItemService
    {
        IEnumerable<Item> GetAll();

        Item GetItem(int id);

        IEnumerable<Item> GetFilteredItems(Dictionary<string, string> filters);

        string SaveItems(ItemDTO itemCreateBindingModel);

        string UpdateItem(int id, ItemDTO itemCreateBindingModelDTO);

        string DeleteItem(int id);
    }
}

using ASPNetCoreMastersToDoList.Service.DTO;

namespace ASPNetCoreMastersToDoList.Service
{
    public interface IItemsService
    {
        string GetAll();

        string GetItem(int id);

        string GetFilteredItems(Dictionary<string, string> filters);

        string SaveItems(ItemCreateBindingModelDTO itemCreateBindingModel);

        string UpdateItem(int id, ItemCreateBindingModelDTO itemCreateBindingModelDTO);

        string DeleteItem(int id);
    }
}

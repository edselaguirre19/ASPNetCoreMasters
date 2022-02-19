using ASPNetCoreMastersToDoList.Service.DTO;

namespace ASPNetCoreMastersToDoList.Service
{
    public interface IItemsService
    {
        int GetItems(int id);

        void SaveItems(ItemCreateBindingModelDTO itemCreateBindingModel);
    }
}

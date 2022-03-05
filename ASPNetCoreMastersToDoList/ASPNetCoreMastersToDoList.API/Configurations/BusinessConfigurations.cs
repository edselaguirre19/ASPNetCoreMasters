using ASPNetCoreMastersToDoList.Repository;
using ASPNetCoreMastersToDoList.Service;

namespace ASPNetCoreMastersToDoList.API.Configurations
{
    public static class BusinessConfigurations
    {
        public static IServiceCollection AddBusinessConfigurations(this IServiceCollection services)
        {
            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton<DataContext>();
            return services;
        }
    }
}

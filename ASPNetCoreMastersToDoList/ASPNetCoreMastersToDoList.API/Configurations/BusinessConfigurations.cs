using ASPNetCoreMastersToDoList.Repository;
using ASPNetCoreMastersToDoList.Service;

namespace ASPNetCoreMastersToDoList.API.Configurations
{
    public static class BusinessConfigurations
    {
        public static IServiceCollection AddBusinessConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<DataContext>();
            services.AddScoped<IUserManagerService, UserManagerService>();
            return services;
        }
    }
}

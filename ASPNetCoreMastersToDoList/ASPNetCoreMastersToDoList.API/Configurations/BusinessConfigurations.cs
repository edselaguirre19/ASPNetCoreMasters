using ASPNetCoreMastersToDoList.Service;

namespace ASPNetCoreMastersToDoList.API.Configurations
{
    public static class BusinessConfigurations
    {
        public static IServiceCollection AddBusinessConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IItemsService, ItemService>();
            return services;
        }
    }
}

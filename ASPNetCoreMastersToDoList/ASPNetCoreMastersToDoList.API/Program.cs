using ASPNetCoreMastersToDoList.API.BindingModels;
using ASPNetCoreMastersToDoList.API.Configurations;
using ASPNetCoreMastersToDoList.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalPerfomanceFilter());
});
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//business config injections
builder.Services.AddBusinessConfigurations();
builder.Services.Configure<Authentication>(builder.Configuration.GetSection("Authentication"));

var app = builder.Build();
var env = app.Environment;

builder.Configuration
  .SetBasePath(env.ContentRootPath)
  .AddJsonFile("appsettings.json", true, true)
  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
  .AddJsonFile("sharedsettings.json", true, true)
  .AddEnvironmentVariables();

//app.MapGet("/", (IItemsService itemService) => itemService.GetItems);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");    
//});

app.Run();

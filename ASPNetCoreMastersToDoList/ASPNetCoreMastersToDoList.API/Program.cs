using ASPNetCoreMastersToDoList.API.Authorization;
using ASPNetCoreMastersToDoList.API.BindingModels;
using ASPNetCoreMastersToDoList.API.Configurations;
using ASPNetCoreMastersToDoList.API.Filters;
using ASPNetCoreMastersToDoList.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341/")
);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalPerfomanceFilter());
});
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Add valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
                new string[] { }
        }
    });
});
builder.Services.AddDbContext<ToDoListDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ToDoListDbContext>()
    .AddDefaultTokenProviders();

SecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["jwt:secret"]));
builder.Services.Configure<JwtOptions>(options => options.SecurityKey = key);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
    options.DefaultScheme = "Bearer";
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanEditItem",
        policy => policy.Requirements.Add(new CanEditItemRequirement()));
});

//business config injections
builder.Services.AddBusinessConfigurations();
//builder.Services.Configure<Authentication>(builder.Configuration.GetSection("Authentication"));

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");    
//});

app.Run();

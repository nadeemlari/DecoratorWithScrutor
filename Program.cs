using DecoratorWithScrutor.Repository;
using DecoratorWithScrutor.Repository.Cached;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.Decorate<ICustomerRepository, CachedCustomerRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

using Inventory.API;
using Inventory.DAL.Context;
using Inventory.DAL.Service;
using Inventory.DAL.Service.Interface;
using Inventory.Service;
using Inventory.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("inventory"), b => b.MigrationsAssembly("Inventory.API"));
});
{
    builder.Services.AddScoped<IUserDataServicve, UserDataService>();
    builder.Services.AddScoped<ILocationDataService, LocationDataService>();
    builder.Services.AddScoped<IGroupDataService, GroupDataService>();
    builder.Services.AddScoped<ICheckoutDataService, CheckoutDataService>();
}
{
    builder.Services.AddScoped<IPasswordCheck, PasswordCheck>();
    builder.Services.AddScoped<IUserService, UserService>();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

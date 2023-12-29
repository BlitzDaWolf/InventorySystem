using AutoMapper;
using Inventory.API.Mapper;
using Inventory.API.ServiceHelpers;
using Inventory.API.Swagger;
using Inventory.DAL.Context;
using Inventory.DAL.Service;
using Inventory.DAL.Service.Interface;
using Inventory.Service;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidAudience = config["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

{
    var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new InventoryMapper());
    });

    IMapper mapper = mapperConfig.CreateMapper();
    builder.Services.AddSingleton(mapper);
}

builder.Services.AddDbContext<InventoryContext>(opt =>
{
    opt.UseSqlite(config.GetConnectionString("inventory"), b => b.MigrationsAssembly("Inventory.API"));
    opt.UseLazyLoadingProxies();
});
{
    builder.Services.AddScoped<IUserDataServicve, UserDataService>();
    builder.Services.AddScoped<ILocationDataService, LocationDataService>();
    builder.Services.AddScoped<IGroupDataService, GroupDataService>();
    builder.Services.AddScoped<ICheckoutDataService, CheckoutDataService>();
    builder.Services.AddScoped<IItemDataService, ItemDataService>();
    builder.Services.AddScoped<ICheckoutDataService, CheckoutDataService>();
}
{
    builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
    builder.Services.AddScoped<IPasswordCheck, PasswordCheck>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IGroupService, GroupService>();
    builder.Services.AddScoped<ILocationService, LocationService>();
    builder.Services.AddScoped<IItemService, ItemService>();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();

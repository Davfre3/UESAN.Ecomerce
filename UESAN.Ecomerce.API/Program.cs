using Microsoft.EntityFrameworkCore;
using UESAN.Ecomerce.CORE.Core.Interfaces;
using UESAN.Ecomerce.CORE.Core.Services;
using UESAN.Ecomerce.CORE.Infrastructure.Data;
using UESAN.Ecomerce.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var connectionString = _configuration.GetConnectionString("DevConnection");

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoriServices, CategoriServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(connectionString));


//build services wirh Mysql



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

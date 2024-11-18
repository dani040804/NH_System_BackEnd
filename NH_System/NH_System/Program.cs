using Microsoft.EntityFrameworkCore;
using Muscle_Designer_Data.Repository;
using NH_Sys_Application.ServiceInterfaces.Product;
using NH_Sys_Application.Services.Product;
using NH_Sys_Domain.Interfaces;
using NH_Sys_Infrastructure.Data;
using NH_Sys_Infrastructure.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DB_PSQL");

builder.Services.AddDbContext<DbDevContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicios para interfaces de los Casos de Usos
builder.Services.AddScoped<IAddProductService, AddProductService>();
builder.Services.AddScoped<IGetProductsService, GetProductsService>();
builder.Services.AddScoped<IUpdateProductService, UpdateProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();



//Servicios para interfaces de Repositorios
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
	app.UseSwagger();
	app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

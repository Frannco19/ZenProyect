using Data;
using Data.Repositories.interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.interfaces;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();

builder.Services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();
builder.Services.AddScoped<ISaleDetailService, SaleDetailService>();

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

builder.Services.AddScoped<IFinancialReportRepository, FinancialReportRepository>();
builder.Services.AddScoped<IFinancialReportService, FinancialReportService>();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:DBConnectionString"]));

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

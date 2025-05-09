using System;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using StockApp.Data;
using StockApp.Interfaces;
using StockApp.Repositories;
using StockApp.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<DbContextStock>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Serviços
builder.Services.AddScoped<IProductService, ProductService>();


// Adicionando suporte ao MVC e adicionar o serviço ao contêiner
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DbContextStock>();
    dbContext.Database.Migrate(); // Aplica migrações automaticamente
}
// Carregar CSS, JS e imagens
app.UseStaticFiles();
// Usando MVC e configurando as rotas
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Mapeando a rota padrão para o controlador e ação

app.Run();

using System;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using StockApp.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbContextStock>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando suporte ao MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Usando MVC e configurando as rotas
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Mapeando a rota padrão para o controlador e ação

app.Run();

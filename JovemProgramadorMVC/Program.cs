using JovemProgramadorMVC.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Data.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connString = builder.Configuration.GetConnectionString("StringConexao");

builder.Services.AddDbContext<JovemProgramadorContexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringConexao"));

});

// var configuration = builder.Configuration;
//builder.Services.AddDbContext<JovemProgramadorContexto>();
//builder.Services.AddDbContext<JovemProgramadorContexto>(opt => opt.UseSqlServer(configuration.GetConnectionString("StringConexao")));
builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

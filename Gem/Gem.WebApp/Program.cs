using Gem.WebApp.Migrations;
using Microsoft.EntityFrameworkCore;
using Gem.WebApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServerSideBlazor();

builder.Services.AddSignalR();

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("GemWebAppContext");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

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

app.MapBlazorHub();
app.MapHub<ChatHub>("/chatHub");

app.Run();

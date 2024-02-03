using Microsoft.EntityFrameworkCore;
using RoyalLibrary.API.Data;
using RoyalLibrary.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var configuration = builder.Configuration;

builder.Services.AddDbContext<EFContext>(options => options.UseMySql(configuration.GetConnectionString("DbContext"),
                new MySqlServerVersion(new Version(8, 0, 11))));

builder.Services.AddScoped<BookServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

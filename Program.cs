using FAQs.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options=>{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FaqsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FAQsCS")));

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
    name: "category-topic",
    pattern: "{controller=Home}/{action=Index}/topic/{topic?}/category/{category?}");

app.MapControllerRoute(
    name: "category",
    pattern: "{controller=Home}/{action=Index}/category/{category?}");

app.MapControllerRoute(
    name: "topic",
    pattern: "{controller=Home}/{action=Index}/topic/{topic?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

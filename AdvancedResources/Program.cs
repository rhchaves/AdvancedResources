using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdvancedResources.Data;
using AdvancedResources.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdvancedResourcesContext>(options =>
    options.UseMySql("server=localhost; database=bd_crud_advanced_resources; uid=root; pwd=root",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));
                    //"server=localhost; database=bd_crud_advanced_resources; user=root; password=root",

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

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

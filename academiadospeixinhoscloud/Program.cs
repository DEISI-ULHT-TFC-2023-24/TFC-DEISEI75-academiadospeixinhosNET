using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using academiadospeixinhoscloud.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<academiadospeixinhoscloudContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("academiadospeixinhoscloudContext") ?? throw new InvalidOperationException("Connection string 'academiadospeixinhoscloudContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//ricardo v0
//miguel
//ricardo v1
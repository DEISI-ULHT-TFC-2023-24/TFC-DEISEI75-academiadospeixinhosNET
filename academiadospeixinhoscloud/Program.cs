using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using academiadospeixinhoscloud.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<academiadospeixinhoscloudContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("academiadospeixinhoscloudContext") ?? throw new InvalidOperationException("Connection string 'academiadospeixinhoscloudContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Add roles services
    .AddEntityFrameworkStores<academiadospeixinhoscloudContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure this is added
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

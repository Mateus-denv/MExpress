using Mexpressapp.Data;
using Mexpressapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// =======================
// SERVICES
// =======================

// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => // Alterado para ApplicationUser
{
    options.SignIn.RequireConfirmedAccount = false; // Alterado para false
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>(); // Alterado para AppDbContext e Adiciona suporte a Roles

// =======================
// Build app
// =======================
var app = builder.Build();

// =======================
// SEED (Roles / Admin)
// =======================

using (var scope = app.Services.CreateScope())
{
    await DbInitializer.SeedRolesAsyns(scope.ServiceProvider);

    // Temporario para garantir que o usuário admin tenha a role Admin.
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var adminUser = await userManager.FindByEmailAsync("admin@mexpress.com");
    if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, "Admin"))
    {
           await userManager.AddToRoleAsync(adminUser, "Admin");

    }
}

// =======================
// Pipeline
// =======================

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{ 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite que o site use arquivos estáticos (CSS, JS, imagens, etc).
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();

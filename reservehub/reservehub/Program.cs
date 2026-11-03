using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using reservehub.Data;

// Cambia 'reservehub.Models' o 'reservehub.Data' según la carpeta donde esté tu Contexto
using reservehub.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Conexión a la Base de Datos
builder.Services.AddDbContext<ReserveHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configuración de Autenticación por Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

// 3. Habilitar Sesiones (para Context.Session en el Layout)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 4. Middleware de Seguridad y Sesión
app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); // Debe ir después de Routing y antes de MapRazorPages

app.MapRazorPages();

app.Run();
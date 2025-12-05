using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Interfaces;
using NewsPortal.Repositories;
using NewsPortal.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICaseDocumentRepository, CaseDocumentRepository>();
builder.Services.AddScoped<ICaseNoteRepository, CaseNoteRepository>();
builder.Services.AddScoped<ILawyerRepository, LawyerRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ICaseRepository, CaseRepository>();
builder.Services.AddScoped<IWhoWeArePageRepository, WhoWeArePageRepository>();
builder.Services.AddScoped<ICallToActionRepository, CallToActionRepository>();

builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();

builder.Services.AddHttpClient<ITranslationService, LibreTranslateService>();

builder.Services.AddAuthentication("AdminCookie")
    .AddCookie("AdminCookie", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Denied";
    });

var app = builder.Build();

var supportedCultures = new[] { "ru", "en" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("ru")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    SeedData.Initialize(db);

    if (!db.AdminUsers.Any())
    {
        db.AdminUsers.Add(new NewsPortal.Models.AdminUser
        {
            Email = "admin@example.com",
            PasswordHash = ComputeSha256Hash("Admin@123")
        });
        db.SaveChanges();
    }
}

static string ComputeSha256Hash(string rawData)
{
    using var sha256 = System.Security.Cryptography.SHA256.Create();
    var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(rawData));
    var sb = new System.Text.StringBuilder();
    foreach (var b in bytes)
        sb.Append(b.ToString("x2"));
    return sb.ToString();
}

app.Run();

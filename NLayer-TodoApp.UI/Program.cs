using Microsoft.Extensions.FileProviders;
using NLayer_TodoApp.Business.DependencyResolvers.Microsoft;
using NLayer_TodoApp.DataAccess.UnitOfWork;
using NLayer_TodoApp.Entities.Domains;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies();
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
// node_modules dizinini statik dosyalar olarak sunmak için PhysicalFileProvider kullanma
var nodeModulesPath = Path.Combine(Directory.GetCurrentDirectory(), "node_modules");

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(nodeModulesPath),
    RequestPath = "/node_modules" // Web üzerinden node_modules'a erişim yolu
});

app.UseHttpsRedirection();      
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
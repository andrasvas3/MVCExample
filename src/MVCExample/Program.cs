using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CelestialBodies_MVC;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.Configure<CookiePolicyOptions>(o => o.Secure = CookieSecurePolicy.Always);
        builder.Services.AddResponseCompression();

        var app = builder.Build();
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.UseResponseCompression();
        app.MapControllerRoute(name: "default", pattern: "{controller=Site}/{action=Home}").WithStaticAssets();
        app.Run();
    }
}

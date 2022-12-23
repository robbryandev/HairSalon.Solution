using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;
using Microsoft.Extensions.DependencyInjection;

namespace HairSalon
{
  class Program
  {
    static void Main(string[] args)
    {
      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<HairSalonContext>(
        dbContextOptions => dbContextOptions
        .UseMySql(
            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"])
        )
    );

      WebApplication app = builder.Build();

      app.UseDeveloperExceptionPage();

      app.UseStaticFiles();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}"
      );

      app.Run();
    }
  }
}

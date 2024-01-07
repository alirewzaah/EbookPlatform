using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using EbookPlatform;
using Microsoft.EntityFrameworkCore;
using EbookPlatform.Core;
using EbookPlatform.Core.Service.Interface;
using EbookPlatform.Core.Service;

internal class Program
{
  
    private static void Main(string[] args)
    {   
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMvc();
        builder.Services.AddDbContext<MyEbookPlatformContext>(options =>
        {
            options.UseSqlServer("Data Source =.;Initial Catalog=EbookPlatform_DB;Integrated Security=true");
            
        });
        builder.Services.AddTransient<ICategoryService, CategoryService>();
        var app = builder.Build();
        app.UseRouting();
        app.UseStaticFiles();
        //app.UseMvcWithDefaultRoute();


        app.MapControllerRoute(
            name:"Area",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            ); 
        app.MapControllerRoute(
             name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
            );

        app.Run();
    }
}
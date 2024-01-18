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
using static Kalamarket.Core.ExtentionMethod.RenderEmail;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public const string Schema = "EbookPlatform";
    private static void Main(string[] args)
    {
     
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMvc();
        builder.Services.AddAuthentication(Schema)
            .AddCookie(Schema, option =>
            {
                option.LoginPath = "/Account/Login";
                option.AccessDeniedPath = "/Account/Login";
                option.ExpireTimeSpan = TimeSpan.FromDays(3);
            }
            );
        builder.Services.AddDbContext<MyEbookPlatformContext>(options =>
        {
            options.UseSqlServer("Data Source =.;Initial Catalog=EbookPlatform_DB;Integrated Security=true");
            
        });
        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Services.AddTransient<IBookService, BookService>();
        builder.Services.AddTransient<ILanguageService, LanguageService>();
        builder.Services.AddTransient<IPublisherService, PublisherService>();
        builder.Services.AddTransient<ITranslatorService, TranslatorService>();
        builder.Services.AddTransient<IAuthorService, AuthorService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IViewRenderService, RenderViewToString>();
        builder.Services.AddTransient<IRoleService, RoleService>();
        var app = builder.Build();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
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
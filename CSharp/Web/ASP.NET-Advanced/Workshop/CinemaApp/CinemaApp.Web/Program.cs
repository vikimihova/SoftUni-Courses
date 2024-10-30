using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Web.Infrastructure.Extensions.ExtensionMethods;

namespace CinemaApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("SqlServer");

            // Add services to the container.
            builder.Services.AddDbContext<CinemaDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }); //Nuget Microsoft Extensions Dependecy Injection package

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:Password:RequireUniqueCharacters");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequireLength");

                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
                options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");

                options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
            })
            .AddEntityFrameworkStores<CinemaDbContext>()
            .AddRoles<IdentityRole<Guid>>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddUserManager<UserManager<ApplicationUser>>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });
            

            // Add repositories for each entity (repository pattern) except for ApplicationUser (UserManager and SignInManager instead)
            builder.Services.AddScoped<IRepository<Movie, Guid>, Repository<Movie, Guid>>();
            builder.Services.AddScoped<IRepository<Cinema, Guid>, Repository<Cinema, Guid>>();
            builder.Services.AddScoped<IRepository<CinemaMovie, object>, Repository<CinemaMovie, object>>();
            builder.Services.AddScoped<IRepository<ApplicationUserMovie, object>, Repository<ApplicationUserMovie, object>>();
            
            // Add other services
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();


            var app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly); // gets the assembly of the view models, using the ErrorViewModel as a starting point

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.ApplyMigrations();
            app.Run();
        }
    }
}

using Football_League.Models.Domain;
using Football_League.Repositories.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.Data
{
    public class StartUpConfig
    {
        public IConfiguration Configuration;
        public static string Server;
        public StartUpConfig(IConfiguration configuration)
        {
            Configuration = configuration;
            Server = Configuration.GetConnectionString("DefaultConnection");
        }

        public void PartOfConfigureServices(IServiceCollection services)
        {

            var migrationAssembly = typeof(StartUpConfig).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt => opt.MigrationsAssembly(migrationAssembly)));

            services.AddIdentityCore<User>(options => { });
            services.AddScoped<IUserStore<User>, UserOnlyStore<User, AppDbContext>>();
            services.AddAuthentication("Identity.Application")
                .AddCookie("Identity.Application");

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Events.OnRedirectToLogin = ctx =>
                {
                    if (ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 401;
                        return Task.FromResult<object>(null);
                    }
                    return Task.CompletedTask;
                };

                opt.Events.OnRedirectToAccessDenied = ctx => {
                    if (ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 403;
                        return Task.FromResult<object>(null);
                    }
                    return Task.CompletedTask;
                };
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.None;
                opt.Cookie.HttpOnly = false;
                opt.Cookie.Name = "FootballApp";
                opt.ExpireTimeSpan = TimeSpan.FromDays(30);
            });
        }
    }
}

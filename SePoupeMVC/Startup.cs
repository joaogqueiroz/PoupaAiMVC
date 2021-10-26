using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SePoupeMVC.Data.Interfaces;
using SePoupeMVC.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //This command enable MVC
            services.AddControllersWithViews();

            //Using cookies and authentication
            services.Configure<CookiePolicyOptions>(options => { options.MinimumSameSitePolicy = SameSiteMode.None; });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //DB connectionString
            var Context_UsuarioDB = Configuration.GetConnectionString("Context_UsuarioDB");
            var Context_QuestoesDB = Configuration.GetConnectionString("Context_QuestoesDB");
            //Dependency injection
            services.AddTransient<IPontosRepository, PontosRepository>(map => new PontosRepository(Context_UsuarioDB, Context_QuestoesDB));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>(map => new UsuarioRepository(Context_UsuarioDB, Context_QuestoesDB));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();

            //Using cookies
            app.UseCookiePolicy();
            //Using authentication
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default", //Initial page
                    pattern: "{controller=Conta}/{action=Login}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebTest.Models;
using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace WebTest
{
    public class Startup
    {


        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new System.Web.Http.Cors.EnableCorsAttribute("https://localhost:44319/", "*", "*");
            config.EnableCors(corsAttr);
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            string con = "Server=(localdb)\\mssqllocaldb;Database=contacts2dbstore;Trusted_Connection=True;";
            // устанавливаем контекст данных
            services.AddDbContext<ContactContext>(options => options.UseSqlServer(con));
            services.AddControllers(); // используем контроллеры без представлений
        }


       

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

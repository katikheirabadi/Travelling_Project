using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Travelling.Extention;
using Travelling.Middleware;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Mapp;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.ModelsServiceRepository.SigninRepository;
//using TravellingCore.ServiceRepository.LoginService;
using TravellingEF.ContextRepository;
using TravellingEF.DataBase;

namespace Travelling
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
            services.AddControllers();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappConfig)));
            services.AddDbContext<TravellingDBContext>(o => { o.UseSqlServer(Configuration.GetConnectionString("TravellConection"), b => b.MigrationsAssembly("Travelling")); });
            services.AddDependency();
            services.AddSwaggerGen(c => c.SwaggerDoc("Travelling", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Travelling", Version = "Travelling_Priject" }));
            // services.AddSwaggerGen(c=>c.SwaggerDoc() )
           
           services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TravellingDBContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/Travelling_Project/swagger.json", "Travelling_Project"));
            //app.UseHttpsRedirection();

            app.UseRouting();
            

            app.UseAuthorization();
            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

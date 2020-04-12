using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckSingletonScopeTransiateInstances.BusinessLogic;
using CheckSingletonScopeTransiateInstances.IInstallers;
using CheckSingletonScopeTransiateInstances.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CheckSingletonScopeTransiateInstances
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
          var installers =  typeof(Startup).Assembly.ExportedTypes.Where(x => 
            typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(installer => installer.Installervice(services, Configuration));

            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My Demo API", Version = "1.0", Description="This document provides information about API",
                  Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                  {
                      Name = ".Net core Swagger test",
                      Email = " buddappa.mca2011@yahoo.com",
                  } });
            });

            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("x-api-version");

            });
         // with out using refeclation  
            //new DataInstaller().Installervice(services, Configuration);
            //new MvcInstaller().Installervice(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Adding Swagger 
            app.UseSwagger();

            // Adding Swagger UI
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", ">NET Core Web API"); });
        }
    }
}

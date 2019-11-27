using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace DotNetCore2Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Configuracion del servicio de Swagger
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("Documentacion", new Info()
                {
                    Title = "Configuracion Swagger",
                    Description = "Configuracion inicial del nuget de Suagger"
                });

                // La siguiente ruta se extrae de propiedades del proyecto, Compilacion y check en la opcion Archivo de documentacion XML
                // ..\DotNetCore2\DotNetCore2Api\DotNetCore2Api\DotNetCore2Api.xml*/
                string filePathXmlDocumentation = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "DotNetCore2Api.xml");
                //Se incluye el xml de documentacion en la configuracion de Swagger
                config.IncludeXmlComments(filePathXmlDocumentation);

                config.AddSecurityDefinition("Bearer", new OAuth2Scheme()
                {
                    Description = "OAuthAutentication example",
                    TokenUrl = "https://miServidorDeAutenticacion.net/oauth2/token",
                    Flow = "myPassword",
                    Type = "oauth2" // puede ser tambien jwt (json web Token)
                });


            }
            );



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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // se configura el middleware del Swagger
            app.UseSwagger();
            app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/Documentacion/swagger.json", "Api de Ejemplo SWAGGER"));
        }
    }
}

using DotNetCore2Api.Services;
using DotNetCore2Api.Services.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2Api.Middleware
{
    /// <summary>
    /// Clase extensiva de Inversion de Control para agregar los servicios en el StartUp
    /// De esta forma podemos realizar la iyeccion de dependencias de todas nuestras clases en solo lugar
    /// </summary>
    public static class IoC
    {
        public static IServiceCollection AddService(IServiceCollection services)
        {
            // Solo se crea una misma instancia Singleton
            services.AddSingleton<IPlayerService, PlayerService>();

            // Otras formas de Inyeccion

            // Se crea una nueva instancia cada vez que ser realice una peticion al controlador
            //services.AddTransient<IPlayerService, PlayerService>();

            // se crea una nueva instacia por contexto
            //services.AddScoped<IPlayerService, PlayerService>();

            return services;
        }
    }
}

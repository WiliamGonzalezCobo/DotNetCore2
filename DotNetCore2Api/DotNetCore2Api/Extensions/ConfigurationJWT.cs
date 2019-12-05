using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2Api.Extensions
{
    /// <summary>
    /// Clase de configuracion de JWT
    /// </summary>
    public static class ConfigurationJWT
    {
        /// <summary>
        /// Agrega el servicio con la configuracion de JWT
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddService(IServiceCollection service, IConfiguration configuration) {
            service.AddAuthorization(options => {
                options.DefaultPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                                            .RequireAuthenticatedUser()
                                            .Build();
            });

            var issuer = configuration["AuthentificationSettings:Issuer"];
            var audience = configuration["AuthentificationSettings:Audience"];
            //se debe validar que la contraseña tenga la suficiente dificultad o dara error.
            var singinKey = configuration["AuthentificationSettings:SigninKey"];

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(singinKey))
                };

            });

            return service;
        }
    }
}

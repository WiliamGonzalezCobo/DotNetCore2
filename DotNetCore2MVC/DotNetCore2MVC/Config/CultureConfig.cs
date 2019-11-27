using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace DotNetCore2MVC.Config
{
    public class CultureConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(config => config.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Culture default
                options.DefaultRequestCulture = new RequestCulture("es-ES", "es-ES");

                // Configure supported cultures and localizations options
                CultureInfo[] supportedCultures = new CultureInfo[] {
                new CultureInfo("en-US"),
                new CultureInfo("es-ES")};

                // Cultures Support
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            IOptions<RequestLocalizationOptions> locOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOption.Value);

        }
    }
}
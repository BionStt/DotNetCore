using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNetCore.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCorsAllowAny(this IApplicationBuilder application)
        {
            application.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        }

        public static void UseException(this IApplicationBuilder application)
        {
            var environment = application.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseHttps(this IApplicationBuilder application)
        {
            application.UseHsts();
            application.UseHttpsRedirection();
        }

        public static void UseSpaAngularServer(this IApplicationBuilder application, string sourcePath, string npmScript)
        {
            var environment = application.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            application.UseSpaStaticFiles();

            application.UseSpa(configuration =>
            {
                configuration.Options.SourcePath = sourcePath;

                if (environment.IsDevelopment())
                {
                    configuration.UseAngularCliServer(npmScript);
                }
            });
        }

        public static void UseSpaProxyServer(this IApplicationBuilder application, string sourcePath, string baseUri)
        {
            var environment = application.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            application.UseSpaStaticFiles();

            application.UseSpa(configuration =>
            {
                configuration.Options.SourcePath = sourcePath;

                if (environment.IsDevelopment())
                {
                    configuration.UseProxyToSpaDevelopmentServer(baseUri);
                }
            });
        }
    }
}

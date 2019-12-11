using DotNetCore.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace DotNetCore.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static AuthenticationBuilder AddAuthenticationJwtBearer(this IServiceCollection services)
        {
            var jsonWebTokenSettings = services.BuildServiceProvider().GetRequiredService<JsonWebTokenSettings>();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jsonWebTokenSettings.Key));

            void JwtBearer(JwtBearerOptions options)
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = securityKey,
                    ValidAudience = jsonWebTokenSettings.Audience,
                    ValidIssuer = jsonWebTokenSettings.Issuer,
                    ValidateAudience = !string.IsNullOrEmpty(jsonWebTokenSettings.Audience),
                    ValidateIssuer = !string.IsNullOrEmpty(jsonWebTokenSettings.Issuer),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            }

            return services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearer);
        }

        public static IDataProtectionBuilder AddDataProtectionDefault(this IServiceCollection services)
        {
            return services.AddDataProtection()
                .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_GCM,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA512
                })
                .SetDefaultKeyLifetime(TimeSpan.FromDays(7));
        }

        public static void AddFileService(this IServiceCollection services)
        {
            services.AddSingleton<IFileService, FileService>();
        }

        public static IMvcBuilder AddMvcJson(this IServiceCollection services)
        {
            static void Mvc(MvcOptions options)
            {
                options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            }

            static void Json(JsonOptions options)
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }

            return services.AddMvc(Mvc).AddJsonOptions(Json);
        }

        public static void AddSpaStaticFiles(this IServiceCollection services, string rootPath)
        {
            services.AddSpaStaticFiles(configuration => configuration.RootPath = rootPath);
        }

        public static void ConfigureFormOptions(this IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
            });
        }
    }
}

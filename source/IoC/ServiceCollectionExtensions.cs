using DotNetCore.Logging;
using DotNetCore.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Reflection;

namespace DotNetCore.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddClassesMatchingInterfaces(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
        }

        public static void AddCryptography(this IServiceCollection services, string key)
        {
            services.AddSingleton<ICryptographyService>(_ => new CryptographyService(key));
        }

        public static void AddDbContextMemory<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddDbContextPool<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
            services.BuildServiceProvider().GetRequiredService<T>().Database.EnsureCreated();
        }

        public static void AddDbContextMigrate<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext
        {
            services.AddDbContextPool<T>(options);
            services.BuildServiceProvider().GetRequiredService<T>().Database.Migrate();
        }

        public static void AddHash(this IServiceCollection services, int iterations, int size)
        {
            services.AddSingleton<IHashService>(_ => new HashService(iterations, size));
        }

        public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires)
        {
            services.AddJsonWebToken(new JsonWebTokenSettings(key, expires));
        }

        public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires, string audience, string issuer)
        {
            services.AddJsonWebToken(new JsonWebTokenSettings(key, expires, audience, issuer));
        }

        public static void AddJsonWebToken(this IServiceCollection services, JsonWebTokenSettings jsonWebTokenSettings)
        {
            services.AddSingleton(_ => jsonWebTokenSettings);
            services.AddSingleton<IJsonWebTokenService, JsonWebTokenService>();
        }

        public static void AddLog(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.AddSingleton<ILogService>(_ => new LogService(configuration));
        }
    }
}

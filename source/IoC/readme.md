# DotNetCore.IoC

The package provides **static classes** with **extensions methods** for **inversion of control**.

## ServiceCollectionExtensions

```cs
public static class ServiceCollectionExtensions
{
    public static void AddClassesMatchingInterfaces(this IServiceCollection services, params Assembly[] assemblies) { }

    public static void AddCryptography(this IServiceCollection services, string key) { }

    public static void AddDbContextMemory<T>(this IServiceCollection services) where T : DbContext { }

    public static void AddDbContextMigrate<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) where T : DbContext { }

    public static void AddHash(this IServiceCollection services, int iterations, int size) { }

    public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires) { }

    public static void AddJsonWebToken(this IServiceCollection services, string key, TimeSpan expires, string audience, string issuer) { }

    public static void AddJsonWebToken(this IServiceCollection services, JsonWebTokenSettings jsonWebTokenSettings) { }

    public static void AddLog(this IServiceCollection services) { }
}
```

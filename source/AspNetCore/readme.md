# DotNetCore.AspNetCore

The package provides action results, attributes, extensions, middlewares and providers for **ASP.NET Core**.

## Attributes

### AuthorizeEnumAttribute

```cs
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class AuthorizeEnumAttribute : AuthorizeAttribute
{
    public AuthorizeEnumAttribute(params object[] roles) { }
}
```

### RouteControllerAttribute

```cs
[AttributeUsage(AttributeTargets.Class)]
public sealed class RouteControllerAttribute : RouteAttribute
{
    public RouteControllerAttribute() : base("[controller]") { }
}
```

## Extensions

### ApplicationBuilderExtensions

```cs
public static class ApplicationBuilderExtensions
{
    public static void UseCorsAllowAny(this IApplicationBuilder application) { }

    public static void UseException(this IApplicationBuilder application) { }

    public static void UseHttps(this IApplicationBuilder application) { }

    public static void UseSpaAngularServer(this IApplicationBuilder application, string sourcePath, string npmScript) { }

    public static void UseSpaProxyServer(this IApplicationBuilder application, string sourcePath, string baseUri) { }

    public static void ConfigureFormOptions(this IServiceCollection services) { }
}
```

### ConfigurationBuilderExtensions

```cs
public static class ConfigurationBuilderExtensions
{
    public static void Configuration(this IConfigurationBuilder builder, HostBuilderContext context) { }
}
```

### HostBuilderExtensions

```cs
public static class HostBuilderExtensions
{
    public static void Run<T>(this IHostBuilder host) where T : class { }
}
```

### HttpRequestExtensions

```cs
public static class HttpRequestExtensions
{
    public static IList<BinaryFile> Files(this HttpRequest request) { }
}
```

### ServiceCollectionExtensions

```cs
public static class ServiceCollectionExtensions
{
    public static AuthenticationBuilder AddAuthenticationJwtBearer(this IServiceCollection services) { }

    public static IDataProtectionBuilder AddDataProtectionDefault(this IServiceCollection services) { }

    public static void AddFileService(this IServiceCollection services) { }

    public static IMvcBuilder AddMvcJson(this IServiceCollection services) { }

    public static void AddSpaStaticFiles(this IServiceCollection services, string rootPath) { }
}
```

## Middlewares

### ExceptionMiddleware

It centralizes exception handling and saves logs.

## Results

### ApiResult

```cs
public class ApiResult : IActionResult
{
    public static IActionResult Create(IResult result) { }

    public static IActionResult Create(object data) { }
}
```

## Services

### IFileService

```cs
public interface IFileService
{
    string GetContentType(string path);
}
```

### FileService

```cs
public class FileService
{
    public string GetContentType(string path) { }
}
```

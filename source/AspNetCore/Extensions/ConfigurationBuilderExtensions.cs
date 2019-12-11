using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DotNetCore.AspNetCore
{
    public static class ConfigurationBuilderExtensions
    {
        public static void Configuration(this IConfigurationBuilder builder, HostBuilderContext context)
        {
            builder
                .AddJsonFile("AppSettings.json")
                .AddJsonFile($"AppSettings.{context.HostingEnvironment.EnvironmentName}.json")
                .AddEnvironmentVariables();
        }
    }
}

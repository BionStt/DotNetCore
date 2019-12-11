using Serilog;

namespace DotNetCore.Logging
{
    public static class LogExtensions
    {
        public static ILogger Data(this ILogger logger, object data)
        {
            return logger.ForContext("@Data", data, true);
        }
    }
}

using Microsoft.Extensions.Hosting;
using Serilog;

namespace Union_of_Volunteers.HostBuilders
{
    public static class BuildLoggingExtension
    {
        public static IHostBuilder BuildLogging(this IHostBuilder builder) => builder.ConfigureServices(
            (context, services) =>
            {
                services.AddSerilog((_, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(context.Configuration));
            });
    }
}
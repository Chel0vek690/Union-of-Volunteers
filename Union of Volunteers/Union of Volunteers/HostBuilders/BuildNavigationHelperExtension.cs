using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.HostBuilders
{
    public static class BuildNavigationHelperExtension
    {
        public static IHostBuilder BuildNavigationHelper(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((content, services) =>
            {
                services.AddSingleton<Project>();
            });
            return hostBuilder;
        }
    }
}

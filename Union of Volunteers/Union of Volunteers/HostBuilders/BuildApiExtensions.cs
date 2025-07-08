using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models.Interfaces;

namespace Union_of_Volunteers.HostBuilders
{
    public static class BuildApiExtensions
    {
        public static IHostBuilder BuildApi(this IHostBuilder builder)
        {

            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ApiHelper>();
                services.AddRefitClient<Api>().ConfigureHttpClient(c => c.BaseAddress = new Uri("http://api-sdr.itlabs.top"));
            });
            return builder;
        }
    }
}
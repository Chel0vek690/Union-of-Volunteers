using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using Microsoft.Extensions.DependencyInjection;
using Union_of_Volunteers.Models.Interfaces;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.ViewModels.Pages;

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
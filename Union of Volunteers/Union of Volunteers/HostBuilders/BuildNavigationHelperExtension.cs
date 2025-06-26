using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Union_of_Volunteers.Helpers;

namespace Union_of_Volunteers.HostBuilders
{
    public static class BuildNavigationHelperExtension
    {
        public static IHostBuilder BuildNavigationHelper(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((content, services) =>
            {
                services.AddSingleton<NavigationHelper>();
            });
            return hostBuilder;
        }
    }
}

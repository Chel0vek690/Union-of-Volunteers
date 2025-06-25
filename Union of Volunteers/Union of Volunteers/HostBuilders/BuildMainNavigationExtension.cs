using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.ViewModels;
using Union_of_Volunteers.ViewModels.Pages;

namespace Union_of_Volunteers.HostBuilders
{
    public static class BuildMainNavigationExtension
    {
        public static IHostBuilder BuildMainNavigation(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<NavigationStore>();
                services.AddUtilityNavigationServices<NavigationStore>();

                services.AddNavigationService<MainPageViewModel, NavigationStore>();
                services.AddNavigationService<AboutPageViewModel, NavigationStore>();

                services.AddTransient<AboutPageViewModel>();
            });

            return builder;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels;
using Union_of_Volunteers.ViewModels.Pages;
using Union_of_Volunteers.ViewModels.Popups;

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
                services.AddNavigationService<ProjectsPageViewModel, NavigationStore>();
                services.AddParameterNavigationService<DonationPageViewModel, NavigationStore, Project>(provider => param => ActivatorUtilities.CreateInstance<DonationPageViewModel>(provider, param));
                services.AddParameterNavigationService<SelectedProjectPageViewModel, NavigationStore, Project>(provider => param => ActivatorUtilities.CreateInstance<SelectedProjectPageViewModel>(provider, param));
            });

            return builder;
        }
    }
}
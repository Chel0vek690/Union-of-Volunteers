using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels;
using Union_of_Volunteers.ViewModels.Pages;
using Union_of_Volunteers.ViewModels.Windows;

namespace Union_of_Volunteers.HostBuilders
{
    public static class BuildViewsExtension
    {
        public static IHostBuilder BuildViews(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                var inactivityConfig = context.Configuration.GetValue<InactivityConfig>("inactivity");
                services.AddSingleton<IMessenger>(_ => new WeakReferenceMessenger());

                services.AddSingleton<InactivityManager<MainPageViewModel>>(s => new InactivityManager<MainPageViewModel>(
                    inactivityConfig ?? new InactivityConfig(60, 10),
                    s.GetRequiredService<NavigationStore>(),
                    s.GetRequiredService<NavigationService<MainPageViewModel>>(),
                    s.GetRequiredService<CloseNavigationService<ModalNavigationStore>>()));

                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<AboutPageViewModel>();
                services.AddSingleton<ProjectsPageViewModel>();
                services.AddSingleton<SelectedProjectPageViewModel>();
                services.AddSingleton(s => new Views.Windows.MainWindow()
                {
                    DataContext = s.GetRequiredService<MainWindowViewModel>()
                });
            });
            return builder;
        }
    }
}

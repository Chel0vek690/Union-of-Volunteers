﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using Serilog;
using System.Windows;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.HostBuilders;
using Union_of_Volunteers.ViewModels.Pages;

namespace Union_of_Volunteers
{
    public partial class App : Application
    {
        private readonly IHost _appHost = CreateHostBuilder().Build();

        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (DebugHelper.IsRunningInDebugMode) throw e.Exception;
            var logger = _appHost.Services.GetRequiredService<ILogger>();
            logger.Error(e.Exception, "Неизвестная ошибка");
            e.Handled = true;
        }

        private static IHostBuilder CreateHostBuilder(string[]? args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .BuildConfiguration()
                .BuildLogging()
                .BuildMainNavigation()
                .BuildModalNavigation()
                .BuildApi()
                .BuildViews()
                .BuildNavigationHelper();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var initialNavigationService =
                _appHost.Services.GetRequiredService<NavigationService<MainPageViewModel>>();

            initialNavigationService.Navigate();
            MainWindow = _appHost.Services.GetRequiredService<Views.Windows.MainWindow>();
            MainWindow.Show();
            await _appHost.StartAsync();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _appHost.StopAsync();
            _appHost.Dispose();
            base.OnExit(e);
        }
    }
}

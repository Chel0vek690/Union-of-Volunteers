using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.ViewModels.Popups;
using Union_of_Volunteers.Views.Popups;

namespace Union_of_Volunteers.HostBuilders
{
    public static class BuildModalNavigationExtension
    {
        public static IHostBuilder BuildModalNavigation(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ModalNavigationStore>();
                services.AddUtilityNavigationServices<ModalNavigationStore>();

                services.AddNavigationService<PasswordPopupViewModel, ModalNavigationStore>(s => new PasswordPopupViewModel(
                    s.GetRequiredService<CloseNavigationService<ModalNavigationStore>>(),
                    context.Configuration.GetValue<string>("exitPassword") ?? "1234"));
                services.AddNavigationService<PaymentMethodViewModel, ModalNavigationStore>();
                services.AddNavigationService<CardMethodPopupViewModel, ModalNavigationStore>();
                services.AddNavigationService<QrMethodPopupViewModel, ModalNavigationStore>();
                services.AddNavigationService<DonationProcessingPopupViewModel, ModalNavigationStore>();
                services.AddNavigationService<DonationSentSuccessfullyPopupViewModel, ModalNavigationStore>();

            });

            return builder;
        }
    }
}           
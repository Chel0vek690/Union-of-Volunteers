using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Services.ServiceCollectionExtensions;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels.Popups;

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
                services.AddParameterNavigationService<PaymentMethodViewModel, ModalNavigationStore, Project>(provider => param => ActivatorUtilities.CreateInstance<PaymentMethodViewModel>(provider, param, provider.GetRequiredService<CloseNavigationService<ModalNavigationStore>>()));
                services.AddParameterNavigationService<CardMethodPopupViewModel, ModalNavigationStore, Project>(provider => param => ActivatorUtilities.CreateInstance<CardMethodPopupViewModel>(provider, param, provider.GetRequiredService<CloseNavigationService<ModalNavigationStore>>()));
                services.AddParameterNavigationService<QrMethodPopupViewModel, ModalNavigationStore, Project>(provider => param => ActivatorUtilities.CreateInstance<QrMethodPopupViewModel>(provider, param, provider.GetRequiredService<CloseNavigationService<ModalNavigationStore>>()));
                services.AddParameterNavigationService<DonationSentSuccessfullyPopupViewModel, ModalNavigationStore, Project>(provider => param => ActivatorUtilities.CreateInstance<DonationSentSuccessfullyPopupViewModel>(provider, param, provider.GetRequiredService<CloseNavigationService<ModalNavigationStore>>()));
                services.AddParameterNavigationService<DonationProcessingPopupViewModel, ModalNavigationStore, Project>(provider => param => ActivatorUtilities.CreateInstance<DonationProcessingPopupViewModel>(provider, param));
            });
            return builder;
        }
    }
}
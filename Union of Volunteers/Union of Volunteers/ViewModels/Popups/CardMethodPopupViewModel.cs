using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Union_of_Volunteers.Helpers;
using System.Threading;
using MvvmNavigationLib.Services;
using System.Threading;
using System.Windows;


namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class CardMethodPopupViewModel: ObservableObject
    {
        [ObservableProperty]
        private string price = "";

        private readonly NavigationService<DonationProcessingPopupViewModel> _donationProcessingPopupViewModel;
        private ModalNavigationStore _modalNavigation;
        private NavigationHelper _navigationHelper;
        private Timer timer;


        public CardMethodPopupViewModel(NavigationHelper navigationHelper, ModalNavigationStore modalNavigation, NavigationService<DonationProcessingPopupViewModel> donationProcessingPopupViewModel)
        {
            _donationProcessingPopupViewModel = donationProcessingPopupViewModel;
            _modalNavigation = modalNavigation;
            _navigationHelper = navigationHelper;
            var price1 = _navigationHelper.Project as string[];
            price = price1[1];
            timer = new Timer((e) =>
            {
                _donationProcessingPopupViewModel.Navigate();
                timer.Dispose();
            }, null, 5000, Timeout.Infinite);
            
        }

        [RelayCommand]
        public void ExitPopup()
        {
            timer.Dispose();
            _modalNavigation.CurrentViewModel = null;
        }
    }
}

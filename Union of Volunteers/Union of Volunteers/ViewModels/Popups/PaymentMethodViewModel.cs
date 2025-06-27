using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainComponents.Popups;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models;
using System.Windows;
using MvvmNavigationLib.Stores;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class PaymentMethodViewModel: ObservableObject
    {
        private readonly ModalNavigationStore _modalNavigation;
        private readonly NavigationHelper _navigationHelper;
        private readonly NavigationService<CardMethodPopupViewModel> _cardMethodPopupViewModel;
        private readonly NavigationService<QrMethodPopupViewModel> _qrMethodPopupViewModel;

        [ObservableProperty]
        private string price = "";

        public PaymentMethodViewModel(NavigationHelper navigationHelper, ModalNavigationStore modalNavigation, NavigationService<CardMethodPopupViewModel> cardMethodPopupViewModel, NavigationService<QrMethodPopupViewModel> qrMethodPopupViewModel)
        {
            _cardMethodPopupViewModel = cardMethodPopupViewModel;
            _qrMethodPopupViewModel = qrMethodPopupViewModel;
            _modalNavigation = modalNavigation;
            _navigationHelper = navigationHelper;
            var price1 = _navigationHelper.Project as string[];
            price = price1[1];

        }

        [RelayCommand]
        public void ExitPopup()
        {
            _modalNavigation.CurrentViewModel = null;
        }

        [RelayCommand]
        public void CardMethod()
        {
            _cardMethodPopupViewModel.Navigate();
        }

        [RelayCommand]
        public void QrMethod()
        {
            _qrMethodPopupViewModel.Navigate();
        }
    }
}

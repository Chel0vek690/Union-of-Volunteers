using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainComponents.Popups;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Union_of_Volunteers.Models;
using System.Windows;
using MvvmNavigationLib.Stores;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class PaymentMethodViewModel: ObservableObject
    {
        private readonly ModalNavigationStore _modalNavigation;
        private readonly ParameterNavigationService<CardMethodPopupViewModel, Project> _cardMethodPopupViewModel;
        private readonly ParameterNavigationService<QrMethodPopupViewModel, Project> _qrMethodPopupViewModel;
        private readonly Project _project;

        [ObservableProperty]
        private string price = "";

        public PaymentMethodViewModel(
            Project navigationHelper, 
            ModalNavigationStore modalNavigation, 
            ParameterNavigationService<CardMethodPopupViewModel, Project> cardMethodPopupViewModel, 
            ParameterNavigationService<QrMethodPopupViewModel, Project> qrMethodPopupViewModel, 
            Project project)
        {
            _cardMethodPopupViewModel = cardMethodPopupViewModel;
            _qrMethodPopupViewModel = qrMethodPopupViewModel;
            _modalNavigation = modalNavigation;
            _project = project;
            price = _project.Price.ToString();
        }

        [RelayCommand]
        public void ExitPopup()
        {
            _modalNavigation.CurrentViewModel = null;
        }

        [RelayCommand]
        public void CardMethod() => _cardMethodPopupViewModel.Navigate(_project);

        [RelayCommand]
        public void QrMethod() => _qrMethodPopupViewModel.Navigate(_project);
    }
}

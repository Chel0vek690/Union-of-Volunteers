using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class DonationSentSuccessfullyPopupViewModel: ObservableObject
    {
        private readonly ModalNavigationStore _modalNavigation;
        public DonationSentSuccessfullyPopupViewModel(ModalNavigationStore modalNavigation)
        {
            _modalNavigation = modalNavigation;
        }

        [RelayCommand]
        public void ExitPopup()
        {
            _modalNavigation.CurrentViewModel = null;
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class DonationProcessingPopupViewModel: ObservableObject
    {
        private readonly NavigationService<DonationSentSuccessfullyPopupViewModel> _donationSentSuccessfullyPopupViewModel;
        private Timer timer;
        public DonationProcessingPopupViewModel(NavigationService<DonationSentSuccessfullyPopupViewModel> donationSentSuccessfullyPopupViewModel)
        {
            _donationSentSuccessfullyPopupViewModel = donationSentSuccessfullyPopupViewModel;
            timer = new Timer((e) =>
            {
                _donationSentSuccessfullyPopupViewModel.Navigate();
                timer.Dispose();
            }, null, 5000, Timeout.Infinite);
        }
    }
}

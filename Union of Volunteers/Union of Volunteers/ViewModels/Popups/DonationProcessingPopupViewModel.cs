using CommunityToolkit.Mvvm.ComponentModel;
using MvvmNavigationLib.Services;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class DonationProcessingPopupViewModel : ObservableObject
    {

        private readonly ParameterNavigationService<DonationSentSuccessfullyPopupViewModel, Project> _donationSentSuccessfullyPopupViewModel;
        private readonly Timer timer;
        private readonly Project _project;
        public DonationProcessingPopupViewModel(ParameterNavigationService<DonationSentSuccessfullyPopupViewModel, Project> donationSentSuccessfullyPopupViewModel, Project project)
        {
            _project = project;
            _donationSentSuccessfullyPopupViewModel = donationSentSuccessfullyPopupViewModel;
            timer = new Timer((e) =>
            {
                _donationSentSuccessfullyPopupViewModel.Navigate(_project);
                timer.Dispose();
            }, null, 5000, Timeout.Infinite);
        }
    }
}

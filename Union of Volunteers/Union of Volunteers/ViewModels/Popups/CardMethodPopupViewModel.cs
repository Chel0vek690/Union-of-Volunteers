using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.Models;


namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class CardMethodPopupViewModel : ObservableObject
    {
        [ObservableProperty]
        private string price = "";

        private readonly ParameterNavigationService<DonationProcessingPopupViewModel, Project> _donationProcessingPopupViewModel;
        private readonly ModalNavigationStore _modalNavigation;
        private readonly Timer timer;
        private readonly Project _project;

        public CardMethodPopupViewModel(
            Project project, 
            ModalNavigationStore modalNavigation, 
            ModalNavigationStore modalNavigationStore, 
            ParameterNavigationService<DonationProcessingPopupViewModel, Project> donationProcessingPopupViewModel)
        {
            _donationProcessingPopupViewModel = donationProcessingPopupViewModel;
            _modalNavigation = modalNavigation;
            _project = project;
            price = _project.Price.ToString();
            timer = new Timer((e) =>
            {
                _donationProcessingPopupViewModel.Navigate(_project);
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

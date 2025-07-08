using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.Models;
using System.Threading;
using MainComponents.Popups;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class CardMethodPopupViewModel : BasePopupViewModel
    {
        [ObservableProperty]
        private string price = "";

        private readonly ParameterNavigationService<DonationProcessingPopupViewModel, Project> _donationProcessingPopupViewModel;
        private readonly Timer timer;
        private readonly Project _project;
        private readonly INavigationService _closeModalNavigationService;

        public CardMethodPopupViewModel(
            INavigationService closeModalNavigationService, 
            Project project, 
            ParameterNavigationService<DonationProcessingPopupViewModel,Project> donationProcessingPopupViewModel) 
            : base(closeModalNavigationService)
        {
            _closeModalNavigationService = closeModalNavigationService;
            _donationProcessingPopupViewModel = donationProcessingPopupViewModel;
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
            _closeModalNavigationService.Navigate();
        }
    }
}

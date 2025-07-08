using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels.Popups;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly NavigationService<AboutPageViewModel> _aboutNavigationService;
        private readonly NavigationService<ProjectsPageViewModel> _projectsNavigationService;
        private readonly ParameterNavigationService<DonationPageViewModel, Project> _donationPageViewModel;
        private readonly Project _project = new();

        public MainPageViewModel(
            NavigationService<AboutPageViewModel> aboutNavigationService, 
            NavigationService<ProjectsPageViewModel> projectsNavigationService, 
            ParameterNavigationService<DonationPageViewModel, Project> donationPageViewModel,
            ParameterNavigationService<CardMethodPopupViewModel, Project> cardMethodPopupViewModel)
        {
            _donationPageViewModel = donationPageViewModel;
            _aboutNavigationService = aboutNavigationService;
            _projectsNavigationService = projectsNavigationService;
        }

        [RelayCommand]
        private void GoToAbout() => _aboutNavigationService.Navigate();

        [RelayCommand]
        private void GoToProjects() => _projectsNavigationService.Navigate();

        [RelayCommand]
        private void GoToDonation() => _donationPageViewModel.Navigate(_project);
    }
}
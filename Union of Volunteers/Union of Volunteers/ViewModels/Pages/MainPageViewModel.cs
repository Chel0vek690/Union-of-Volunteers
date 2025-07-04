﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly NavigationService<AboutPageViewModel> _aboutNavigationService;
        private readonly NavigationService<ProjectsPageViewModel> _projectsNavigationService;
        private readonly NavigationService<DonationPageViewModel> _donationNavigationService;

        public MainPageViewModel(NavigationService<AboutPageViewModel> aboutNavigationService, NavigationService<ProjectsPageViewModel> projectsNavigationService, NavigationService<DonationPageViewModel> donationNavigationService)
        {
            _donationNavigationService = donationNavigationService;
            _aboutNavigationService = aboutNavigationService;
            _projectsNavigationService = projectsNavigationService;
        }

        [RelayCommand]
        private void GoToAbout() => _aboutNavigationService.Navigate();

        [RelayCommand]
        private void GoToProjects() => _projectsNavigationService.Navigate();

        [RelayCommand]
        private void GoToDonation() => _donationNavigationService.Navigate();
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class SelectedProjectPageViewModel : ObservableObject
    {
        private readonly Project _project;
        private readonly NavigationService<ProjectsPageViewModel> _projectsNavigationService;
        private readonly ParameterNavigationService<DonationPageViewModel, Project> _donationPageViewModel;


        [ObservableProperty]
        private string selectedTitle;

        [ObservableProperty]
        private string selectedImageUrl;

        [ObservableProperty]
        private string selectedDescription;

        public SelectedProjectPageViewModel(
            Project project, 
            NavigationService<ProjectsPageViewModel> projectsNavigationService, 
            ParameterNavigationService<DonationPageViewModel, Project> donationPageViewModel)
        {
            _donationPageViewModel = donationPageViewModel;
            _projectsNavigationService = projectsNavigationService;
            _project = project;
            SelectedTitle = _project.Title;
            SelectedImageUrl = _project.ImageUrl;
            SelectedDescription = _project.Description;
        }

        [RelayCommand]
        public void CancelButton()
        {
            _projectsNavigationService.Navigate();
        }

        [RelayCommand]
        public void Donate()
        {
            _donationPageViewModel.Navigate(_project);
        }
    }

}

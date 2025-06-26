using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class SelectedProjectPageViewModel : ObservableObject
    {
        private readonly NavigationHelper _navigationHelper;
        private readonly NavigationService<ProjectsPageViewModel> _projectsNavigationService;

        [ObservableProperty]
        private string selectedTitle;

        [ObservableProperty]
        private string selectedImageUrl;

        [ObservableProperty]
        private string selectedDescription;

        public SelectedProjectPageViewModel(NavigationHelper navigationHelper, NavigationService<ProjectsPageViewModel> projectsNavigationService)
        {
            _projectsNavigationService = projectsNavigationService;
            _navigationHelper = navigationHelper;
            var selectedProject = _navigationHelper.Project as ProjectsApi;
            SelectedTitle = selectedProject.title;
            SelectedImageUrl = selectedProject.ImageUrl;
            SelectedDescription = selectedProject.description;
        }

        [RelayCommand]
        public void CancelButton()
        {
            _projectsNavigationService.Navigate();
        }
    }

}

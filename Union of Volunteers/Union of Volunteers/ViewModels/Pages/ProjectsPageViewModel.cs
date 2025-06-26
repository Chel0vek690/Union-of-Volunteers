using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System.Diagnostics;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.ViewModels.Pages
{

    public partial class ProjectsPageViewModel : ObservableObject
    {
        private readonly NavigationService<SelectedProjectPageViewModel> _selectedProjectNavigationService;

        [ObservableProperty]
        public List<ProjectsApi> projects;

        private readonly ApiHelper _apiService;
        public ProjectsPageViewModel(ApiHelper apiService, NavigationService<SelectedProjectPageViewModel> selectedProjectNavigationService)
        {
            _selectedProjectNavigationService = selectedProjectNavigationService;
            _apiService = apiService;
            _ = LoadData();
        }

        private async Task LoadData()
        {
            Projects = await _apiService.GetProjects();
        }

        [RelayCommand]
        private void SelectProject(ProjectsApi project)
        {
            Debug.WriteLine($"Выбран проект: {project.title}");
            _selectedProjectNavigationService.Navigate();

        }
    }
}

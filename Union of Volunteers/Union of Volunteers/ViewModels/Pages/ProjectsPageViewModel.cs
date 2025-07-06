using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using Serilog;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.ViewModels.Pages
{

    public partial class ProjectsPageViewModel : ObservableObject
    {
        private readonly NavigationService<SelectedProjectPageViewModel> _selectedProjectNavigationService;
        private readonly NavigationService<MainPageViewModel> _mainPageNavigationService;
        private readonly NavigationHelper _navigationHelper;
        private readonly ILogger _logger;

        [ObservableProperty]
        public List<ProjectsApi> projects;

        private readonly ApiHelper _apiService;
        public ProjectsPageViewModel(ApiHelper apiService, NavigationService<SelectedProjectPageViewModel> selectedProjectNavigationService, NavigationHelper navigationHelper, NavigationService<MainPageViewModel> mainPageNavigationService, ILogger logger)
        {
            _mainPageNavigationService = mainPageNavigationService;
            _navigationHelper = navigationHelper;
            _selectedProjectNavigationService = selectedProjectNavigationService;
            _apiService = apiService;
            _logger = logger;
            LoadData();
        }

        private async void LoadData()
        {
            Projects = await _apiService.GetProjects(); 
        }

        [RelayCommand]
        private void SelectProject(ProjectsApi project)
        {
            _navigationHelper.Project = project;
            _logger.Information("Выбран проект: {ProjectTitle}", project.title);
            _selectedProjectNavigationService.Navigate();
        }

        [RelayCommand]
        private void CancelButton()
        {
            _mainPageNavigationService.Navigate();
        }
    }
}
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
        private readonly ParameterNavigationService<SelectedProjectPageViewModel, Project> _selectedProjectNavigationService;
        private readonly NavigationService<MainPageViewModel> _mainPageNavigationService;
        private readonly ILogger _logger;
        private readonly ApiHelper _apiService;
        private readonly Project _project = new();

        [ObservableProperty]
        public List<ProjectsApi> projects;

        
        public ProjectsPageViewModel(
            ApiHelper apiService, 
            ParameterNavigationService<SelectedProjectPageViewModel, Project> selectedProjectNavigationService, 
            NavigationService<MainPageViewModel> mainPageNavigationService, 
            ILogger logger)
        {
            _mainPageNavigationService = mainPageNavigationService;
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
            _project.Id = project.id;
            _project.Title = project.title;
            _project.Description = project.description;
            _project.ImageUrl = project.ImageUrl;
            _logger.Information("Выбран проект: {ProjectTitle}", project.title);
            _selectedProjectNavigationService.Navigate(_project);
        }

        [RelayCommand]
        private void CancelButton()
        {
            _mainPageNavigationService.Navigate();
        }
    }
}
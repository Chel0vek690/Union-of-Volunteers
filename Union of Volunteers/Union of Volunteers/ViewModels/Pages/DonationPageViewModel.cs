using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels.Popups;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class DonationPageViewModel : ObservableObject
    {
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        private readonly ParameterNavigationService<PaymentMethodViewModel, Project> _paymentMethodNavigation;
        private readonly Project? _project;
        private readonly ApiHelper _apiService;

        [ObservableProperty]
        private List<ProjectsApi> projects;

        [ObservableProperty]
        private ProjectsApi selectedProject;

        public DonationPageViewModel(
            ApiHelper apiService, 
            NavigationService<MainPageViewModel> mainNavigationService, 
            ParameterNavigationService<PaymentMethodViewModel, Project> paymentMethodNavigation, 
            Project? project)
        {
            _paymentMethodNavigation = paymentMethodNavigation;
            _mainNavigationService = mainNavigationService;
            _apiService = apiService;
            _project = project;
            RadioButton100 = true;
            LoadData();
            ownAmount = "Своя сумма";
        }

        private async void LoadData()
        {

            Projects = await _apiService.GetProjects();
            Projects.Insert(0, new ProjectsApi()
            {
                id = -1,
                title = "Без проекта",
                description = "",
                image = ""
            });
            if (_project.Id == null) SelectedProject = Projects[0];
            else SelectedProject = Projects[Convert.ToInt32(_project.Id)];
        }

        private bool _radioButton5000;
        public bool RadioButton5000
        {
            get => _radioButton5000;
            set
            {
                if (_radioButton5000 != value)
                {
                    _radioButton5000 = value;
                    OnPropertyChanged(nameof(RadioButton5000));
                    if (value) OwnAmount = "Своя сумма";
                }
            }
        }

        private bool _radioButton1000;
        public bool RadioButton1000
        {
            get => _radioButton1000;
            set
            {
                if (_radioButton1000 != value)
                {
                    _radioButton1000 = value;
                    OnPropertyChanged(nameof(RadioButton1000));
                    if (value) OwnAmount = "Своя сумма";
                }
            }
        }

        private bool _radioButton500;
        public bool RadioButton500
        {
            get => _radioButton500;
            set
            {
                if (_radioButton500 != value)
                {
                    _radioButton500 = value;
                    OnPropertyChanged(nameof(RadioButton500));
                    if (value) OwnAmount = "Своя сумма";
                }
            }
        }

        private bool _radioButton100;
        public bool RadioButton100
        {
            get => _radioButton100;
            set
            {
                if (_radioButton100 != value)
                {
                    _radioButton100 = value;
                    OnPropertyChanged(nameof(RadioButton100));
                    if (value) OwnAmount = "Своя сумма";
                }
            }
        }

        [ObservableProperty]
        private string? ownAmount = "";

        private void AllRadioButtonsFalse()
        {
            RadioButton100 = false;
            RadioButton500 = false;
            RadioButton1000 = false;
            RadioButton5000 = false;
        }

        [RelayCommand]
        public void Number(object parameter)
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = parameter.ToString();
                AllRadioButtonsFalse();
            }
            else OwnAmount += parameter.ToString();
        }

        [RelayCommand]
        public void ButtonBackspace()
        {
            if (OwnAmount.Length > 0 && OwnAmount != "Своя сумма")
            {
                OwnAmount = OwnAmount.Remove(OwnAmount.Length - 1);
                if (string.IsNullOrEmpty(OwnAmount))
                {
                    OwnAmount = "Своя сумма";
                    RadioButton100 = true;
                }
            }
        }

        [RelayCommand]
        public void CancelButton()
        {
            _mainNavigationService.Navigate();
        }

        [RelayCommand]
        public void GoToPaymentMethod()
        {
            Project project = new();
            if (selectedProject.title != "Без проекта")
            {
                if (OwnAmount != "Своя сумма")
                {
                    if (Convert.ToInt32(OwnAmount) > 9)
                    {
                        project.Title = SelectedProject.title;
                        project.Price = Convert.ToInt32(OwnAmount);
                        _paymentMethodNavigation.Navigate(project);
                    }
                }
                else
                {

                    if (_radioButton5000)
                    {
                        project.Title = SelectedProject.title;
                        project.Price = 5000;
                    }
                    else if (_radioButton1000)
                    {
                        project.Title = SelectedProject.title;
                        project.Price = 1000;
                    }
                    else if (_radioButton500)
                    { 
                        project.Title = SelectedProject.title;
                        project.Price = 500;
                    } 
                    else if (_radioButton100)
                    {
                        project.Title = SelectedProject.title;
                        project.Price = 100;
                    }

                    _paymentMethodNavigation.Navigate(project);
                }
            }

        }
    }
}
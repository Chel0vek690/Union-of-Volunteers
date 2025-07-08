using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels.Popups;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class DonationPageViewModel : ObservableValidator, INotifyDataErrorInfo
    {
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        private readonly ParameterNavigationService<PaymentMethodViewModel, Project> _paymentMethodNavigation;
        private readonly Project? _project;
        private readonly ApiHelper _apiService;

        [ObservableProperty]
        private List<ProjectsApi> projects;

        [ObservableProperty]
        private ProjectsApi selectedProject;

        private readonly Dictionary<string, List<string>> _errors = [];

        public new bool HasErrors => _errors.ContainsKey(nameof(OwnAmount)) && _errors[nameof(OwnAmount)].Count > 0;
        public bool HasErrorsComboBox => _errors.ContainsKey(nameof(SelectedProject)) && _errors[nameof(SelectedProject)].Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.SelectMany(e => e.Value);
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return Enumerable.Empty<string>();
        }

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
        public void Number0()
        {
            if (OwnAmount != "Своя сумма") OwnAmount += "0";
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
            ValidateComboBox();
            ValidateOwnAmount();
            if (selectedProject.title != "Без проекта")
            {
                if (OwnAmount != "Своя сумма")
                {
                    if (Convert.ToInt32(OwnAmount) > 9)
                    {
                        _project.Title = SelectedProject.title;
                        _project.Price = Convert.ToInt32(OwnAmount);
                        _paymentMethodNavigation.Navigate(_project);
                    }
                }
                else
                {
                    if (_radioButton5000)
                    {
                        _project.Title = SelectedProject.title;
                        _project.Price = 5000;
                    }
                    else if (_radioButton1000)
                    {
                        _project.Title = SelectedProject.title;
                        _project.Price = 1000;
                    }
                    else if (_radioButton500)
                    {
                        _project.Title = SelectedProject.title;
                        _project.Price = 500;
                    }
                    else if (_radioButton100)
                    {
                        _project.Title = SelectedProject.title;
                        _project.Price = 100;
                    }
                    _paymentMethodNavigation.Navigate(_project);
                }
            }
        }

        private void ValidateOwnAmount()
        {
            _errors.Remove(nameof(OwnAmount));
            if (OwnAmount != "Своя сумма")
            {
                if (!int.TryParse(OwnAmount, out int amount) || amount < 10)
                {
                    _errors[nameof(OwnAmount)] = ["Сумма должна быть числом не меньше 10."];
                }
            }
            OnPropertyChanged(nameof(HasErrors));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(OwnAmount)));
        }

        private void ValidateComboBox()
        {
            _errors.Remove(nameof(SelectedProject));
            if (SelectedProject == null || SelectedProject.title == "Без проекта")
            {
                _errors[nameof(SelectedProject)] = ["Выберите проект"];
            }
            OnPropertyChanged(nameof(HasErrorsComboBox));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(SelectedProject)));
        }
    }
}
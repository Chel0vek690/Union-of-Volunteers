using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Union_of_Volunteers.Helpers;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels.Popups;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class DonationPageViewModel : ObservableObject
    {
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        private readonly NavigationService<PaymentMethodViewModel> _paymentMethodService;
        private readonly NavigationHelper _navigationHelper;
        private ApiHelper _apiService;

        [ObservableProperty]
        private List<ProjectsApi> projects;

        [ObservableProperty]
        private string selectedProject;

        public DonationPageViewModel(ApiHelper apiService, NavigationService<MainPageViewModel> mainNavigationService, NavigationService<PaymentMethodViewModel> paymentMethodService, NavigationHelper navigationHelper)
        {
            _navigationHelper = navigationHelper;
            _paymentMethodService = paymentMethodService;
            RadioButton100 = true;
            _mainNavigationService = mainNavigationService;
            _apiService = apiService;
            _ = LoadData();
            _navigationHelper = navigationHelper;
            ownAmount = "Своя сумма";
        }

        private async Task LoadData()
        {
            Projects = await _apiService.GetProjects();
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
        public void Number1()
        {
            if (ownAmount == "Своя сумма")
            { 
                OwnAmount = "1";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "1";
            
            
        }

        [RelayCommand]
        public void Number2()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "2";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "2";
        }

        [RelayCommand]
        public void Number3()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "3";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "3";
        }

        [RelayCommand]
        public void Number4()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "4";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "4";
        }

        [RelayCommand]
        public void Number5()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "5";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "5";
        }

        [RelayCommand]
        public void Number6()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "6";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "6";
        }

        [RelayCommand]
        public void Number7()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "7";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "7";
        }

        [RelayCommand]
        public void Number8()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "8";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "8";
        }

        [RelayCommand]
        public void Number9()
        {
            if (ownAmount == "Своя сумма")
            {
                OwnAmount = "9";
                AllRadioButtonsFalse();
            }
            else OwnAmount += "9";
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
            MessageBox.Show(selectedProject);
            if(OwnAmount != "Своя сумма")
            {
                _navigationHelper.Project = OwnAmount;
            }
            else
            {
                if (_radioButton5000) _navigationHelper.Project = "5000";
                else if (_radioButton1000) _navigationHelper.Project = "1000";
                else if (_radioButton500) _navigationHelper.Project = "500";
                else if (_radioButton100) _navigationHelper.Project = "100";
            }
            
            _paymentMethodService.Navigate();
        }
    }
}
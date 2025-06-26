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

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class DonationPageViewModel : ObservableObject
    {
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        private ApiHelper _apiService;

        [ObservableProperty]
        private List<ProjectsApi> projects;

        public DonationPageViewModel(ApiHelper apiService, NavigationService<MainPageViewModel> mainNavigationService)
        {
            RadioButton100 = true;
            _mainNavigationService = mainNavigationService;
            _apiService = apiService;
            _ = LoadData();
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
                    if (value) OwnAmount = "";
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
                    if (value) OwnAmount = "";
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
                    if (value) OwnAmount = "";
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
                    if (value) OwnAmount = "";
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
            AllRadioButtonsFalse();
            OwnAmount += "1";
        }

        [RelayCommand]
        public void Number2()
        {
            AllRadioButtonsFalse();
            OwnAmount += "2";
        }

        [RelayCommand]
        public void Number3()
        {
            OwnAmount += "3";
        }

        [RelayCommand]
        public void Number4()
        {
            AllRadioButtonsFalse();
            OwnAmount += "4";
        }

        [RelayCommand]
        public void Number5()
        {
            AllRadioButtonsFalse();
            OwnAmount += "5";
        }

        [RelayCommand]
        public void Number6()
        {
            AllRadioButtonsFalse();
            OwnAmount += "6";
        }

        [RelayCommand]
        public void Number7()
        {
            AllRadioButtonsFalse();
            OwnAmount += "7";
        }

        [RelayCommand]
        public void Number8()
        {
            AllRadioButtonsFalse();
            OwnAmount += "8";
        }

        [RelayCommand]
        public void Number9()
        {
            AllRadioButtonsFalse();
            OwnAmount += "9";
        }

        [RelayCommand]
        public void Number0()
        {
            if (OwnAmount != "") OwnAmount += "0";
        }

        [RelayCommand]
        public void ButtonBackspace()
        {
            OwnAmount = (OwnAmount.Length > 0) ? OwnAmount.Remove(OwnAmount.Length - 1) : "";
            if (OwnAmount != "") AllRadioButtonsFalse();
            else RadioButton100 = true;
        }

        [RelayCommand]
        public void CancelButton()
        {
            _mainNavigationService.Navigate();
        }
    }
}

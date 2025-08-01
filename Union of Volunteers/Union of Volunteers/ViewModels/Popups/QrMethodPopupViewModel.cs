﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class QrMethodPopupViewModel : BasePopupViewModel
    {
        private readonly Timer timer;
        private readonly ParameterNavigationService<DonationProcessingPopupViewModel, Project> _donationProcessingPopupViewModel;
        private readonly Project _project;
        private readonly INavigationService _closeModalNavigationService;

        [ObservableProperty]
        private string price = "";
        public QrMethodPopupViewModel(
            INavigationService closeModalNavigationService,
            ModalNavigationStore modalNavigation,
            ParameterNavigationService<DonationProcessingPopupViewModel, Project> donationProcessingPopupViewModel,
            Project project)
            : base(closeModalNavigationService)
        {
            _closeModalNavigationService = closeModalNavigationService;
            _project = project;
            _donationProcessingPopupViewModel = donationProcessingPopupViewModel;
            price = _project.Price.ToString();
            timer = new Timer((e) =>
            {
                _donationProcessingPopupViewModel.Navigate(_project);
                timer.Dispose();
            }, null, 5000, Timeout.Infinite);

        }

        [RelayCommand]
        public void ExitPopup()
        {
            timer.Dispose();
            _closeModalNavigationService.Navigate();
        }
    }
}

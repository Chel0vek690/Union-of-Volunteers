using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class PaymentMethodViewModel : BasePopupViewModel
    {
        private readonly ModalNavigationStore _modalNavigation;
        private readonly ParameterNavigationService<CardMethodPopupViewModel, Project> _cardMethodPopupViewModel;
        private readonly ParameterNavigationService<QrMethodPopupViewModel, Project> _qrMethodPopupViewModel;
        private Project _project;
        INavigationService _closeModalNavigationService;

        [ObservableProperty]
        private string price = "";

        public PaymentMethodViewModel(
            INavigationService closeModalNavigationService,
            ModalNavigationStore modalNavigation,
            ParameterNavigationService<CardMethodPopupViewModel, Project> cardMethodPopupViewModel,
            ParameterNavigationService<QrMethodPopupViewModel, Project> qrMethodPopupViewModel,
            Project project)
            : base(closeModalNavigationService)
        {
            _closeModalNavigationService = closeModalNavigationService;
            _cardMethodPopupViewModel = cardMethodPopupViewModel;
            _qrMethodPopupViewModel = qrMethodPopupViewModel;
            _modalNavigation = modalNavigation;
            _project = project;
            price = _project.Price.ToString();
        }

        [RelayCommand]
        public void ExitPopup() => _closeModalNavigationService.Navigate();

        [RelayCommand]
        public void CardMethod() => _cardMethodPopupViewModel.Navigate(_project);

        [RelayCommand]
        public void QrMethod() => _qrMethodPopupViewModel.Navigate(_project);
    }
}

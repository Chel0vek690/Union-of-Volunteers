using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly NavigationService<AboutPageViewModel> _aboutNavigationService;

        public MainPageViewModel(NavigationService<AboutPageViewModel> aboutNavigationService)
        {
            _aboutNavigationService = aboutNavigationService;
        }

        [RelayCommand]
        private void GoToAbout() => _aboutNavigationService.Navigate();
    }
}

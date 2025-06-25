using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System.Collections.ObjectModel;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class AboutPageViewModel : ObservableObject
    {
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        public ObservableCollection<AboutSlide> Slides { get; } = [];

        [ObservableProperty]
        private int currentSlideIndex;

        public AboutSlide? CurrentSlide => Slides.Count > 0 ? Slides[CurrentSlideIndex] : null;

        public AboutPageViewModel(NavigationService<MainPageViewModel> mainNavigationService)
        {
            _mainNavigationService = mainNavigationService;
            Slides.Add(new AboutSlide { Title = "Об организации", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization1.png" });
            Slides.Add(new AboutSlide { Title = "Об организации", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization2.png" });
            Slides.Add(new AboutSlide { Title = "Об организации", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization3.png" });
            Slides.Add(new AboutSlide { Title = "Наша команда", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization4.png" });
            Slides.Add(new AboutSlide { Title = "Наша команда", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization5.png" });
        }

        [RelayCommand]
        private void NextSlide()
        {
            if (CurrentSlideIndex < Slides.Count - 1)
            {
                CurrentSlideIndex++;
                OnPropertyChanged(nameof(CurrentSlide));
            }
        }

        [RelayCommand]
        private void PrevSlide()
        {
            if (CurrentSlideIndex > 0)
            {
                CurrentSlideIndex--;
                OnPropertyChanged(nameof(CurrentSlide));
            }
        }

        [RelayCommand]
        private void CancelButton() => _mainNavigationService.Navigate();
    }

}

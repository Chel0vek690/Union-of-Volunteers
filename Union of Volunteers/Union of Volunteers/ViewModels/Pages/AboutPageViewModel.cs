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

        [ObservableProperty]
        private string backgroundButtonRight = "#12529E";

        [ObservableProperty]
        private string backgroundButtonLeft = "#3312529E";

        public AboutSlide? CurrentSlide => Slides.Count > 0 ? Slides[CurrentSlideIndex] : null;

        public AboutPageViewModel(NavigationService<MainPageViewModel> mainNavigationService)
        {
            _mainNavigationService = mainNavigationService;
            Slides.Add(new AboutSlide { Id = 1, Title = "Об организации", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization1.png" });
            Slides.Add(new AboutSlide { Id = 2, Title = "Об организации", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization2.png" });
            Slides.Add(new AboutSlide { Id = 3, Title = "Об организации", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization3.png" });
            Slides.Add(new AboutSlide { Id = 4, Title = "Наша команда", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization4.png" });
            Slides.Add(new AboutSlide { Id = 5, Title = "Наша команда", Image = "pack://application:,,,/;component/Resources/Images/AboutOrganization5.png" });
        }

        [RelayCommand]
        private void NextSlide()
        {
            if (CurrentSlideIndex < Slides.Count - 1)
            {
                if (CurrentSlide.Id == 4) BackgroundButtonRight = "#3312529E";
                else BackgroundButtonLeft = "#12529E";
                CurrentSlideIndex++;
                OnPropertyChanged(nameof(CurrentSlide));
            }
        }

        [RelayCommand]
        private void PrevSlide()
        {
            if (CurrentSlide.Id == 2) BackgroundButtonLeft = "#3312529E";
            else BackgroundButtonRight = "#12529E";
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

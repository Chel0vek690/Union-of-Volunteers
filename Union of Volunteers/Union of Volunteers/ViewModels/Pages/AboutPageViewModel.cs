using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Union_of_Volunteers.ViewModels.Pages
{
    public partial class AboutPageViewModel : ObservableObject
    {
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        public ObservableCollection<AboutSlide> Slides { get; } = [];

        [ObservableProperty]
        private int currentSlideIndex;

        //[ObservableProperty]
        //private string backgroundButtonRight = "#12529E";

        //[ObservableProperty]
        //private string backgroundButtonLeft = "#3312529E";
        [ObservableProperty]
        private bool backgroundL = false;

        [ObservableProperty]
        private bool backgroundR = true;

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
            CurrentSlideIndex++;
            MessageBox.Show(CurrentSlide.Id.ToString());
            if (CurrentSlide.Id > 1) BackgroundL = true;
            if (CurrentSlide.Id == 5) BackgroundR = false;
            else BackgroundR = true;
            OnPropertyChanged(nameof(CurrentSlide));
            
        }

        [RelayCommand]
        private void PrevSlide()
        {
            CurrentSlideIndex--;
            if (CurrentSlide.Id < 5) BackgroundR = true;
            if (CurrentSlide.Id == 1) BackgroundL = false;
            else BackgroundL = true;
            OnPropertyChanged(nameof(CurrentSlide));
        }

        [RelayCommand]
        private void CancelButton() => _mainNavigationService.Navigate();
    }

}

using CommunityToolkit.Mvvm.Input;
using MainComponents.Popups;
using MvvmNavigationLib.Services;
using MvvmNavigationLib.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Union_of_Volunteers.Models;
using Union_of_Volunteers.ViewModels.Pages;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class DonationSentSuccessfullyPopupViewModel : BasePopupViewModel
    {
        private readonly ModalNavigationStore _modalNavigation;
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        private readonly Project _project;
        private readonly INavigationService _closeModalNavigationService;



        public DonationSentSuccessfullyPopupViewModel(
            INavigationService closeModalNavigationService,
            ModalNavigationStore modalNavigation,
            Project project,
            NavigationService<MainPageViewModel> mainNavigationService)
            : base(closeModalNavigationService)
        {
            _closeModalNavigationService = closeModalNavigationService;
            _mainNavigationService = mainNavigationService;
            _project = project;
            _modalNavigation = modalNavigation;
            var title = _project.Title;
            var sum = _project.Price;
            WriteJson(title, sum);
        }

        private void WriteJson(string? title, int? sum)
        {
            string filePath = "JsonData.json";

            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.WriteAllText(filePath, "[]");
            }

            string json = System.IO.File.ReadAllText(filePath);
            JArray array = string.IsNullOrWhiteSpace(json)
                ? new JArray()
                : JArray.Parse(json);

            var user = array.FirstOrDefault(obj => (string)obj["title"] == title);

            if (user == null)
            {
                JObject newObj = new JObject
                {
                    ["title"] = title,
                    ["sum"] = Convert.ToInt32(sum)
                };

                array.Add(newObj);
            }
            else
            {
                user["sum"] = Convert.ToInt32(sum) + (int)user["sum"];
            }

            System.IO.File.WriteAllText(filePath, array.ToString(Formatting.Indented));

        }

        [RelayCommand]
        public void ExitPopup()
        {
            _closeModalNavigationService.Navigate();
            _mainNavigationService.Navigate();
        }
    }
}

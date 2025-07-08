using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmNavigationLib.Stores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Markup;
using Union_of_Volunteers.Models;
using static System.Net.WebRequestMethods;
using MvvmNavigationLib.Services;
using Union_of_Volunteers.ViewModels.Pages;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class DonationSentSuccessfullyPopupViewModel: ObservableObject
    {
        private readonly ModalNavigationStore _modalNavigation;
        private readonly NavigationService<MainPageViewModel> _mainNavigationService;
        private readonly Project _project;



        public DonationSentSuccessfullyPopupViewModel(
            ModalNavigationStore modalNavigation, 
            Project project, 
            NavigationService<MainPageViewModel> mainNavigationService)
        {
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
            _modalNavigation.CurrentViewModel = null;
            _mainNavigationService.Navigate();
        }
    }
}

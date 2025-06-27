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
using Union_of_Volunteers.Helpers;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Markup;
using Union_of_Volunteers.Models;
using static System.Net.WebRequestMethods;

namespace Union_of_Volunteers.ViewModels.Popups
{
    public partial class DonationSentSuccessfullyPopupViewModel: ObservableObject
    {
        private readonly ModalNavigationStore _modalNavigation;
        private NavigationHelper _navigationHelper;

        public DonationSentSuccessfullyPopupViewModel(ModalNavigationStore modalNavigation, NavigationHelper navigationHelper)
        {
            _navigationHelper = navigationHelper;
            _modalNavigation = modalNavigation;
            var data = _navigationHelper.Project as string[];
            WriteJson(data);
        }

        private void WriteJson(string[] data)
        {
            string filePath = "JsonData.json";

            // 1. Инициализация файла
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.WriteAllText(filePath, "[]"); // Важно: создаём ПУСТОЙ массив
            }

            // 2. Чтение и парсинг
            string json = System.IO.File.ReadAllText(filePath);
            JArray array = string.IsNullOrWhiteSpace(json)
                ? new JArray()
                : JArray.Parse(json);

            // 3. Поиск объекта
            var user = array.FirstOrDefault(obj => (string)obj["title"] == data[0]);

            if (user == null)
            {
                // Создаём новый объект (НЕ сериализуем в строку отдельно!)
                JObject newObj = new JObject
                {
                    ["title"] = data[0],
                    ["sum"] = Convert.ToInt32(data[1])
                };

                array.Add(newObj); // Добавляем в массив
            }
            else
            {
                user["sum"] = Convert.ToInt32(data[1]) + (int)user["sum"];
            }

            // 4. Перезаписываем ВЕСЬ файл актуальным массивом
            System.IO.File.WriteAllText(filePath, array.ToString(Formatting.Indented));

        }

        [RelayCommand]
        public void ExitPopup()
        {
            _modalNavigation.CurrentViewModel = null;
        }
    }
}

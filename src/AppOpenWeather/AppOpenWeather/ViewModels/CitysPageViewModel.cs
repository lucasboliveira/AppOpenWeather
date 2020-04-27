using AppOpenWeather.Models;
using AppOpenWeather.Services;
using AppOpenWeather.Views;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace AppOpenWeather.ViewModels
{
    public class CitysPageViewModel : INotifyPropertyChanged
    {
        protected INavigationService _navigationService;

        private ObservableCollection<Models.Data> _data;
        public ObservableCollection<Models.Data> Data
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }

        public CitysPageViewModel()
        {
            _navigationService = DependencyService.Get<INavigationService>();
            Data = new ObservableCollection<Data>();
            var citys = LoadJsonCitys();

            foreach (var item in citys)            
                Data.Add(item);
            
        }
        private List<Data> LoadJsonCitys()
        {
            string jsonFileName = "city.list.json";

            var assembly = typeof(CitysPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<JsonData>(jsonString);
                var lista = result.Data.OrderBy(a => a.Name).ToList();

               return lista;
            }
        }

        Data _selectedItem;
        public Data SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                    GoToDetaisPage(value.Id);
                }
            }
        }

        void  GoToDetaisPage(int cityID)
        {
             _navigationService.NavigationToDetails(cityID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}

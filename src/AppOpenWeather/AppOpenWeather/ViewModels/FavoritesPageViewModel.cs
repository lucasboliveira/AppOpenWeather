using AppOpenWeather.Models;
using AppOpenWeather.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppOpenWeather.ViewModels
{
    public class FavoritesPageViewModel : BaseClimateViewModel
    {
        public ICommand SearchCommand { get; private set; }

        public FavoritesPageViewModel()
        {
            _favoriteRepository = new FavoriteRepository();
            SearchCommand = new Command(async () => await GoToCitysPage());

            _list = new List();

            GetFavorites();
        }

        public void GetFavorites()
        {
            var favorites = _favoriteRepository.GetAllFavorite().Result;
            
            if (favorites.Any())
                GetDetailsCitys(favorites);
            else
            {
                ClimateList = new List<List>();
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                NotifyPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    GetFavorites();
                    IsRefreshing = false;
                });
            }
        }
        private void GetDetailsCitys(List<Favorite> favorites)
        {
            var citysID = String.Join(",", favorites.Select(p => p.CityID));

            using (var client = new HttpClient())
            {
                var uri = "https://api.openweathermap.org/data/2.5/group?id={0}&lang=pt_br&units=metric&appid=ddcfbd4b040c49d82071ccde8a592d6b";
                var newURI = string.Format(uri, citysID);
                var result = client.GetStringAsync(newURI).Result;

                var Climate = JsonConvert.DeserializeObject<Climate>(result);

                ClimateList = Climate.List;
            }

        }

        List _selectedItem;
        public List SelectedItem
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

        void GoToDetaisPage(int CityID)
        {
            _navigationService.NavigationToDetails(CityID);
        }

        private async Task GoToCitysPage()
        {
            await _navigationService.NavigationToCitys();
        }
    }
}

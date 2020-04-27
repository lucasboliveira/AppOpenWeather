using AppOpenWeather.Models;
using AppOpenWeather.Services;
using AppOpenWeather.Views;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppOpenWeather.ViewModels
{
    public class DetailsPageViewModel : BaseClimateViewModel
    {
        private int _selectedID;
        private bool _isFavorite;
        private Favorite favoriteItem;

        public ICommand SaveCommand { get; private set; }

        public bool Favorite
        {
            get => _isFavorite;
            set
            {
                _isFavorite = value;
                NotifyPropertyChanged(nameof(Favorite));
            }
        }

        public DetailsPageViewModel(int cityID)
        {
            SaveCommand = new Command(() => SaveDeleteFavorite());

            _favoriteRepository = new FavoriteRepository();
            _selectedID = cityID;
            _list = new List();

            favoriteItem = _favoriteRepository.GetFavorite(cityID).Result;
            _isFavorite = favoriteItem == null ? false : true;

            GetDetailsCity();

        }

        private async Task GetDetailsCity()
        {
            using (var client = new HttpClient())
            {
                var uri = "https://api.openweathermap.org/data/2.5/group?id={0}&lang=pt_br&units=metric&appid=ddcfbd4b040c49d82071ccde8a592d6b";
                var newURI = string.Format(uri, _selectedID);
                var result = client.GetStringAsync(newURI).Result;

                var clima = JsonConvert.DeserializeObject<Climate>(result);

                _list = clima.List.FirstOrDefault();
                _list.Weather[0].Description = _list.Weather[0].Description.ToUpper();
            }

        }

        private void SaveDeleteFavorite()
        {
            if (Favorite == false)
            {
                var favorito = new Favorite
                {
                    CityID = _selectedID,
                    Name = _list.Name
                };

                _favoriteRepository.InsertFavorite(favorito);

                Favorite = true;

                foreach (var item in App.Current.MainPage.Navigation.NavigationStack)
                {
                    if (item.GetType().Name == "EmptyPage")
                    {
                        App.Current.MainPage.Navigation.RemovePage(item);
                        App.Current.MainPage.Navigation.InsertPageBefore(new FavoritesPage(), App.Current.MainPage.Navigation.NavigationStack.ToList()[0]);
                        break;
                    }
                }

            }
            else
            {
                _favoriteRepository.DeleteFavorite(favoriteItem);
                Favorite = false;


            }

            
        }

    }
}

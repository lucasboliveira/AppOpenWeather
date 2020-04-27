using System.Threading.Tasks;

namespace AppOpenWeather.Services
{
    class NavigationService : INavigationService
    {
        public async Task NavigationToCitys()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.CitysPage());
        }

        public  void NavigationToDetails(int cityID)
        {

            App.Current.MainPage.Navigation.PushAsync(new Views.DetailsPage(cityID));
        }

        public async Task NavigationToFavorites()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.FavoritesPage());
        }

        public async void PopAsyncService()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

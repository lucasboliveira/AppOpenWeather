using System.Threading.Tasks;

namespace AppOpenWeather.Services
{
    public interface INavigationService
    {
        Task NavigationToFavorites();
        Task NavigationToCitys();
        void NavigationToDetails(int ID);
        void PopAsyncService();
    }
}

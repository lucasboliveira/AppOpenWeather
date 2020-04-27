using AppOpenWeather.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppOpenWeather.ViewModels
{
    public class EmptyPageViewModel
    {
        public ICommand CitysCommand { get; private set; }
        protected INavigationService _navigationService;

        public EmptyPageViewModel()
        {
            _navigationService = new NavigationService();

            CitysCommand = new Command(async () => await GoToCitysPage());
        }

        private async Task GoToCitysPage()
        {
            await _navigationService.NavigationToCitys();
        }
    }
}

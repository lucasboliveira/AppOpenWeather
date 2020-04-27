using AppOpenWeather.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOpenWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage()
        {
            InitializeComponent();

            BindingContext = new FavoritesPageViewModel();
        }

    }
}
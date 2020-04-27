using AppOpenWeather.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOpenWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitysPage : ContentPage
    {
        public CitysPage()
        {
            InitializeComponent();

            BindingContext = new CitysPageViewModel();
        }
    }
}
using AppOpenWeather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppOpenWeather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyPage : ContentPage
    {
        public EmptyPage()
        {
            InitializeComponent();
            BindingContext = new EmptyPageViewModel();
        }
    }
}
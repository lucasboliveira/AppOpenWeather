using AppOpenWeather.Models;
using AppOpenWeather.Services;
using AppOpenWeather.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace AppOpenWeather
{
    public partial class App : Application
    {
        IFavoriteRepository _favoriteRepository;

        public App()
        {
            InitializeComponent();           


            DependencyService.Register<INavigationService, NavigationService>();
            _favoriteRepository = new FavoriteRepository();

        }

        protected override void OnStart()
        {
            //MainPage = new NavigationPage(new CitysPage());

            //var favorite = new Favorite
            //{
            //    CityID = 3469058,
            //    Name = "Brasilia"
            //};

            //_favoriteRepository.InsertFavorite(favorite);

            var result = _favoriteRepository.GetAllFavorite().Result;

            //MainPage = new NavigationPage(new CitysPage());

            if (result.Count == 0)
                MainPage = new NavigationPage(new EmptyPage());
            else
                MainPage = new NavigationPage(new FavoritesPage());
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

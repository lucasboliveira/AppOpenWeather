using AppOpenWeather.Models;
using AppOpenWeather.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace AppOpenWeather.ViewModels
{
    public class BaseClimateViewModel : INotifyPropertyChanged
    {
        protected INavigationService _navigationService;

        public IFavoriteRepository _favoriteRepository;

        public Climate _climate;
        public List _list;

        public BaseClimateViewModel()
        {
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string DateNow
        {
            get => GetDate();
        }

        public string Name
        {
            get => _list.Name;
            set
            {
                _list.Name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public double Temp
        {
            get => _list.Main.Temp;
            set
            {
                _list.Main.Temp = value;
                NotifyPropertyChanged(nameof(Temp));
            }
        }
        public double TempMin
        {
            get => _list.Main.Temp_Min;
            set
            {
                _list.Main.Temp_Min = value;
                NotifyPropertyChanged(nameof(TempMin));
            }
        }
        public double TempMax
        {
            get => _list.Main.Temp_Max;
            set
            {
                _list.Main.Temp_Max = value;
                NotifyPropertyChanged(nameof(TempMax));
            }
        }

        public string Icon
        {
            get => _list.Weather[0].Icon;
            set
            {
                _list.Weather[0].Icon = value;
                NotifyPropertyChanged(nameof(Icon));
            }
        }

        public string Description
        {
            get => _list.Weather[0].Description;
            set
            {
                _list.Weather[0].Description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        List<List> _climateList;
        public List<List> ClimateList
        {
            get => _climateList;
            set
            {
                _climateList = value;
                NotifyPropertyChanged(nameof(ClimateList));
            }
        }

        private string GetDate()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            var date = DateTime.Now.ToString("dddd 'às' HH:mm", culture);
            return char.ToUpper(date[0]) + date.Substring(1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

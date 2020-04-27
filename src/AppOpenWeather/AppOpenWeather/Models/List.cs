using System.Collections.Generic;

namespace AppOpenWeather.Models
{
    public class List
    {
        public Coord Coord { get; set; }
        public Sys Sys { get; set; }
        public IList<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using System.Collections.Generic;

namespace AppOpenWeather.Models
{
    public class Data
    {
        public int Id { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int Zoom { get; set; }
    }

    public class JsonData
    {
        public IList<Data> Data { get; set; }
    }
}

using SQLite;

namespace AppOpenWeather.Models
{
    public class Favorite
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
    }
}


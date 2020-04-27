using AppOpenWeather.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppOpenWeather.Helpers
{
    public class FavoriteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FavoriteDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Favorite.db3");

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Favorite>().Wait();
        }

        public Task<List<Favorite>> GetFavoritoAsync()
        {
            return _database.Table<Favorite>().OrderBy(a => a.Name).ToListAsync();
        }
        
        public Task<Favorite> GetFavoritoAsync(int cityID)
        {
            return _database.Table<Favorite>()
                            .Where(i => i.CityID == cityID)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFavoritoAsync(Favorite favorite)
        {
            if (favorite.ID != 0)
            {
                return _database.UpdateAsync(favorite);
            }
            else
            {
                return _database.InsertAsync(favorite);
            }
        }

        public Task<int> DeleteFavoritoAsync(Favorite favorito)
        {
            return _database.DeleteAsync(favorito);
        }

        public Task<int> DeleteFavoritoAsync(int cityID)
        {
            var favorito = GetFavoritoAsync(cityID);

            return _database.DeleteAsync(favorito);
        }
    }
}

using AppOpenWeather.Helpers;
using AppOpenWeather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppOpenWeather.Services
{
    class FavoriteRepository : IFavoriteRepository
    {
        FavoriteDatabase _favoriteDatabase;

        public FavoriteRepository()
        {
            _favoriteDatabase = new FavoriteDatabase();
        }

        public Task<List<Favorite>> GetAllFavorite()
        {
            return _favoriteDatabase.GetFavoritoAsync();
        }

        public Task<Favorite> GetFavorite(int cityID)
        {
            return _favoriteDatabase.GetFavoritoAsync(cityID);
        }

        public void DeleteFavorite(Favorite favorito)
        {
            _favoriteDatabase.DeleteFavoritoAsync(favorito);
        }

        public void DeleteFavorite(int cityID)
        {
            _favoriteDatabase.DeleteFavoritoAsync(cityID);
        }

        public void InsertFavorite(Favorite favorito)
        {
            _favoriteDatabase.SaveFavoritoAsync(favorito);
        }
    }
}

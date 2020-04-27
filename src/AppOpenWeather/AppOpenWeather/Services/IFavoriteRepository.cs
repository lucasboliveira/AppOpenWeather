using AppOpenWeather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppOpenWeather.Services
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetAllFavorite();
        Task<Favorite> GetFavorite(int cityID);
        void DeleteFavorite(Favorite favorito);
        void DeleteFavorite(int cityID);
        void InsertFavorite(Favorite favorite);
    }
}

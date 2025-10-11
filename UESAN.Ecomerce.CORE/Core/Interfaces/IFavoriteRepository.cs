using UESAN.Ecomerce.CORE.Core.Entities;

namespace UESAN.Ecomerce.CORE.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<int> DeleteFavorite(int id);
        Task<IEnumerable<Favorite>> GetFavorites();
        Task<Favorite?> GetFavoriteById(int id);
        Task<int> InsertFavorite(Favorite favorite);
    }
}
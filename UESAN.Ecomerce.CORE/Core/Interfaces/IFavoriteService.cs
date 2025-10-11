using UESAN.Ecomerce.CORE.Core.DTOs;

namespace UESAN.Ecomerce.CORE.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<int> DeleteFavorite(int id);
        Task<FavoriteDetaiDTO?> GetFavoriteById(int id);
        Task<IEnumerable<FavoriteDetaiDTO>> GetFavorites();
        Task<int> InsertFavorite(FavoriteCreateDTO favoriteCreateDTO);
    }
}
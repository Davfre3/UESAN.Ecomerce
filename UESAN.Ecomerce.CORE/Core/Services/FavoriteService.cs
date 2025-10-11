using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.DTOs;
using UESAN.Ecomerce.CORE.Core.Interfaces;


namespace UESAN.Ecomerce.CORE.Core.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public async Task<IEnumerable<FavoriteDetaiDTO>> GetFavorites()
        {
            var favorites = await _favoriteRepository.GetFavorites();
            var favoriteDTOs = new List<FavoriteDetaiDTO>();

            foreach (var favorite in favorites)
            {
                var favoriteDTO = new FavoriteDetaiDTO();
                favoriteDTO.Id = favorite.Id;

                var favoriteUserDTO = new UserFavoriteDTO();
                favoriteUserDTO.Id = favorite.User.Id;
                favoriteUserDTO.FirstName = favorite.User.FirstName;
                favoriteUserDTO.LastName = favorite.User.LastName;

                favoriteDTO.User = favoriteUserDTO;

                var favoriteProductDTO = new ProductFavoriteDTO();
                favoriteProductDTO.Id = favorite.Product.Id;
                favoriteProductDTO.Description = favorite.Product.Description;
                favoriteProductDTO.Price = (decimal)favorite.Product.Price;
                favoriteProductDTO.Stock = (int)favorite.Product.Stock;

                favoriteDTO.Product = favoriteProductDTO;

                favoriteDTOs.Add(favoriteDTO);
            }
            return favoriteDTOs;
        }

        public async Task<FavoriteDetaiDTO?> GetFavoriteById(int id)
        {
            var favorite = await _favoriteRepository.GetFavoriteById(id);
            if (favorite == null)
            {
                return null;
            }
            var favoriteDTO = new FavoriteDetaiDTO
            {
                Id = favorite.Id,
                User = new UserFavoriteDTO
                {
                    Id = favorite.User.Id,
                    FirstName = favorite.User.FirstName,
                    LastName = favorite.User.LastName
                },
                Product = new ProductFavoriteDTO
                {
                    Id = favorite.Product.Id,
                    Description = favorite.Product.Description,
                    Price = (decimal)favorite.Product.Price,
                    Stock = (int)favorite.Product.Stock
                }
            };
            return favoriteDTO;
        }
        public async Task<int> InsertFavorite(FavoriteCreateDTO favoriteCreateDTO)
        {
            var favorite = new Entities.Favorite();
            favorite.UserId = favoriteCreateDTO.UserId;
            favorite.ProductId = favoriteCreateDTO.ProductId;
            favorite.CreatedAt = DateTime.Now;
            var newFavoriteId = await _favoriteRepository.InsertFavorite(favorite);
            return newFavoriteId;
        }

        public async Task<int> DeleteFavorite(int id)
        {
            return await _favoriteRepository.DeleteFavorite(id);
        }

    }
}

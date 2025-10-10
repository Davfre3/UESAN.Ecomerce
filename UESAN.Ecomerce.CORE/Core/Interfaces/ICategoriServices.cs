using UESAN.Ecomerce.CORE.Core.DTOs;

namespace UESAN.Ecomerce.CORE.Core.Interfaces
{
    public interface ICategoriServices
    {
        Task<int> CreateCategory(CategoriCreateDTO categoryCreateDTO);
        Task<bool> DeleteCategory(int id);
        Task<bool> DeleteCategoryLogic(int id);
        Task<IEnumerable<CategoriListDTO>> GetAllCategories();
        Task<CategoriListDTO?> GetCategoryById(int id);
        Task UpdateCategory(CategoriListDTO categoriListDTO);
    }
}
using UESAN.Ecomerce.CORE.Core.Entities;

namespace UESAN.Ecomerce.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task DeleteCategory(int id);
        Task DeleteCategoryLogic(int id);
        Task<IEnumerable<Category>> GetCategories();
        IEnumerable<Category> GetCategoriesAll();
        Task<Category?> GetCategoriesId(int id);
        Task<int> InsertCategory(Category category);
        Task UpdateCategory(Category category);
    }
}
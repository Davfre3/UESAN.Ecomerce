using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.DTOs;
using UESAN.Ecomerce.CORE.Core.Entities;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.CORE.Core.Services
{
    public class CategoriServices : ICategoriServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoriListDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoryDTOs = new List<CategoriListDTO>();

            foreach (var category in categories)
            {
                var categoryDTO = new CategoriListDTO();
                categoryDTO.Id = category.Id;
                categoryDTO.Description = category.Description;
                categoryDTOs.Add(categoryDTO);
            }
            return categoryDTOs;
        }

        public async Task<CategoriListDTO?> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoriesId(id);
            if (category == null)
            {
                return null;
            }
            var categoryDTO = new CategoriListDTO
            {
                Id = category.Id,
                Description = category.Description,
            };
            return categoryDTO;
        }
        public async Task<int> CreateCategory(CategoriCreateDTO categoryCreateDTO)
        {
            var category = new Category();
            category.Description = categoryCreateDTO.Description;
            category.IsActive = true;
            var newCategoryId = await _categoryRepository.InsertCategory(category);
            return newCategoryId;
        }

        public async Task UpdateCategory(CategoriListDTO categoriListDTO)
        {
            var category = new Category();
            category.Id = categoriListDTO.Id;
            category.Description = categoriListDTO.Description;
            await _categoryRepository.UpdateCategory(category);
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var existingCategory = await _categoryRepository.GetCategoriesId(id);
            if (existingCategory == null)
            {
                return false;
            }
            await _categoryRepository.DeleteCategory(id);
            return true;
        }

        public async Task<bool> DeleteCategoryLogic(int id)
        {
            var existingCategory = await _categoryRepository.GetCategoriesId(id);
            if (existingCategory == null)
            {
                return false;
            }
            await _categoryRepository.DeleteCategoryLogic(id);
            return true;
        }
    }
}

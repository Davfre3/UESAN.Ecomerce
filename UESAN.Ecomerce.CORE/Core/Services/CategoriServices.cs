using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Ecomerce.CORE.Core.DTOs;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.CORE.Core.Services
{
    public class CategoriServices
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
         
    }
}

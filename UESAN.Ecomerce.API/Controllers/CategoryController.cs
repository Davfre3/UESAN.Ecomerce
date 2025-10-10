using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Ecomerce.CORE.Core.DTOs;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoriServices _categoryServices;

        //public CategoryController(ICategoryRepository categoryRepository)
        public CategoryController(ICategoriServices categoriServices)
        {
            
            _categoryServices = categoriServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryServices.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesId(int id)
        {
            var category = await _categoryServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        /*public async Task<IActionResult> InsertCategory(UESAN.Ecomerce.CORE.Core.Entities.Category category)
        {
            var newCategoryId = await _categoryRepository.InsertCategory(category);
            return CreatedAtAction(nameof(GetCategoriesId), new { id = newCategoryId }, category);
        }*/
        public async Task<IActionResult> CreateCategory(
            [FromBody] CategoriCreateDTO CategoryCreateDTO)
        {
            if (CategoryCreateDTO == null)
            {
                return BadRequest();
            }
            var newCategoryId = await _categoryServices.CreateCategory(CategoryCreateDTO);
            return CreatedAtAction(nameof(GetCategoriesId),
                new { id = newCategoryId }, CategoryCreateDTO);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryServices.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryServices.DeleteCategory(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoriCreateDTO CategoryCreateDTO)
        {
            if (CategoryCreateDTO == null)
            {
                return BadRequest();
            }
            var existingCategory = await _categoryServices.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            // Crear un nuevo CategoryListDTO usando los datos proporcionados y el id
            var categoryToUpdate = new CategoriListDTO
            {
                // Asumiendo que CategoryListDTO tiene al menos Id y Description
                Id = id,
                Description = CategoryCreateDTO.Description
            };
            await _categoryServices.UpdateCategory(categoryToUpdate);
            return NoContent();
        }

        }
}

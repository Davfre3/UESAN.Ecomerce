using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesId(int id)
        {
            var category = await _categoryRepository.GetCategoriesId(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(UESAN.Ecomerce.CORE.Core.Entities.Category category)
        {
            var newCategoryId = await _categoryRepository.InsertCategory(category);
            return CreatedAtAction(nameof(GetCategoriesId), new { id = newCategoryId }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoriesId(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryRepository.DeleteCategory(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UESAN.Ecomerce.CORE.Core.Entities.Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            var existingCategory = await _categoryRepository.GetCategoriesId(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            await _categoryRepository.UpdateCategory(category);
            return NoContent();
        }

    }
}

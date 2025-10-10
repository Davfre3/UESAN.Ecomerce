using Microsoft.AspNetCore.Mvc;
using UESAN.Ecomerce.CORE.Core.DTOs;
using UESAN.Ecomerce.CORE.Core.Interfaces;
using UESAN.Ecomerce.CORE.Core.Services;

namespace UESAN.Ecomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productServices.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productServices.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO dto)
        {
            if (dto == null)
                return BadRequest();

            var id = await _productServices.CreateProduct(dto);
            return CreatedAtAction(nameof(GetProductById), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO dto)
        {
            if (dto == null || id != dto.Id)
                return BadRequest();

            var result = await _productServices.UpdateProduct(dto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productServices.DeleteProduct(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
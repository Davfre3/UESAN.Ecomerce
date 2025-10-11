using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Ecomerce.CORE.Core.DTOs;
using UESAN.Ecomerce.CORE.Core.Interfaces;

namespace UESAN.Ecomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var favorites = await _favoriteService.GetFavorites();
            return Ok(favorites);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoriteById(int id)
        {
            var favorite = await _favoriteService.GetFavoriteById(id);
            if (favorite == null)
                return NotFound();
            return Ok(favorite);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFavorite([FromBody] FavoriteCreateDTO dto)
        {
            if (dto == null)
                return BadRequest();
            var id = await _favoriteService.InsertFavorite(dto);
            return CreatedAtAction(nameof(GetFavoriteById), new { id }, dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var result = await _favoriteService.DeleteFavorite(id);
            if (result == 0)
                return NotFound();
            return NoContent();
        }
    }
}

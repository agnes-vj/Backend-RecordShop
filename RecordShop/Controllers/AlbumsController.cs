using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;
using RecordShop.Model;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumsController : ControllerBase
    {
        public IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }
        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            try
            {
                var albums = _albumsService.GetAllAlbums();
                if (!albums.Any())
                {
                    return NotFound("No Albums Found.");
                }
                return Ok(albums);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred. Please try again later." });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
            return null;
        }
        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            return null;
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateAlbum(int id)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            return null;
        }

    }
}

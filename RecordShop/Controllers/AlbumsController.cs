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
            List<AlbumDTO> albums = null;
            try
            {
                albums = _albumsService.GetAllAlbums();

            }
            catch (RecordShopException ex)
            {
                if (ex.Status == ErrorStatus.Not_Found)
                    return NotFound($"Albums not found");
                if (ex.Status == ErrorStatus.Internal_Server_Error)
                    return NotFound("An unexpected error occurred. Please try again later.");

            }
            return Ok(albums);
        }
            
        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
            AlbumDTO album = null;
            try
            {
                album = _albumsService.GetAlbumById(id);                
                
            }
            catch (RecordShopException ex)
            {
                if (ex.Status == ErrorStatus.Not_Found)
                    return NotFound($"Album with id {id} not found");
                if (ex.Status == ErrorStatus.Internal_Server_Error)
                    return NotFound("An unexpected error occurred. Please try again later.");

            }   
            return Ok(album);      
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

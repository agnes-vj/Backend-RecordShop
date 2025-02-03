using Microsoft.AspNetCore.Mvc;
using RecordShop.Services;
using RecordShop.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
            var response = _albumsService.GetAllAlbums();
            List<AlbumDTO> albums = response.albumDTOs;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(albums),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("No Albums Found"),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }
            
        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {

            var response = _albumsService.GetAlbumById(id);
            AlbumDTO album = response.albumDTO;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(album),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("No Albums Found"),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };

        }
        [HttpPost]
        public IActionResult PostAlbum([FromBody] AlbumDTO albumDTO)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return BadRequest();
            }
            var response = _albumsService.AddAlbum(albumDTO);
            AlbumDTO album = response.albumDTO;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(album),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.ALREADY_EXISTS => BadRequest("Album Already Exists."),
                ExecutionStatus.ARTIST_NOT_FOUND => NotFound("Artist Not Found"),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

        [HttpPut("{id}")]
        public IActionResult PutAlbum(int id, AlbumDTO albumDTO)
        {
            var response = _albumsService.ReplaceAlbum(id, albumDTO);
            AlbumDTO album = response.albumDTO;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(album),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("Album Not Exists."),
                ExecutionStatus.ARTIST_NOT_FOUND => NotFound("Album Artist Not Exists."),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var response = _albumsService.DeleteAlbum(id);
            
            return response switch
            {
                ExecutionStatus.SUCCESS => Ok(),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("Album does not exist."),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

    }
}

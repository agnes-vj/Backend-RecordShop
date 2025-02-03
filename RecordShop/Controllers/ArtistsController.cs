using Microsoft.AspNetCore.Mvc;
using RecordShop.Model;
using RecordShop.Services;

namespace RecordShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        public IArtistsService _artistsService;

        public ArtistsController(IArtistsService artistsService)
        {
            _artistsService = artistsService;
        }
        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var response = _artistsService.GetAllArtists();
            List<Artist> artists = response.artists;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(artists),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("No Artists Found"),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }

        [HttpGet("{name}")]
        public IActionResult GetAlbum(string name)
        {

            var response = _artistsService.GetArtistByName(name);
            Artist artist = response.artist;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(artist),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.NOT_FOUND => NotFound("No Artist Found in this name"),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };

        }
        [HttpPost]
        public IActionResult PostArtist([FromBody] Artist artist)
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
            var response = _artistsService.AddArtist(artist);
            Artist newArtist = response.artist;
            return response.status switch
            {
                ExecutionStatus.SUCCESS => Ok(newArtist),
                ExecutionStatus.INTERNAL_SERVER_ERROR => StatusCode(500, "Internal Server Error. Try again Later"),
                ExecutionStatus.ALREADY_EXISTS => BadRequest("Artist Already Exists."),
                _ => StatusCode(500, "Internal Server Error. Try again Later")
            };
        }
    }
}

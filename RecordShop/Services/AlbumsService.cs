using RecordShop.Model;
using RecordShop.Repository;

namespace RecordShop.Services
{
    public interface IAlbumsService
    {
        List<AlbumDTO> GetAllAlbums();
    }
    public class AlbumsService : IAlbumsService
    {
        IAlbumsRepository _albumsRepository;
        public AlbumsService(IAlbumsRepository albumsRepository) 
        {
           _albumsRepository = albumsRepository;
        }
        public List<AlbumDTO> GetAllAlbums()
        {
            List<AlbumDTO> albumInfo = _albumsRepository.GetAllAlbums()
                                                     .ToList()
                                                     .Select(a => new AlbumDTO
                                                     {
                                                         Id = a.Id,
                                                         Title = a.Title,
                                                         ArtistName = a.AlbumArtist?.Name ?? "Unknown",
                                                         MusicGenre = a.MusicGenre.ToString(),
                                                         ReleaseYear = a.ReleaseYear,
                                                         Stock = a.Stock
                                                     })
                                                     .ToList();
            return albumInfo;
                                                     
        }

    }

}

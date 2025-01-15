using RecordShop.Model;
using RecordShop.Repository;

namespace RecordShop.Services
{
    public interface IAlbumsService
    {
        List<AlbumDTO> GetAllAlbums();
        public AlbumDTO GetAlbumById(int id);
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
                                                     .Select(a => createAlbumDTO(a))
                                                     .ToList();
            return albumInfo;
                                                     
        }
        public AlbumDTO GetAlbumById(int id)
        {
            var album =_albumsRepository.FindAlbumById(id);
        

            if (album == null)            
                throw new RecordShopException(ErrorStatus.Not_Found, $"Sorry, Album with {id} Not Found");
            
            return createAlbumDTO(album);
        }

        public Album AddAlbum(AlbumDTO album)
        {
            return null;
        }
        public Album UpdateAlbum(int id)
        {
            return null;
        }
        public void DeleteAlbum(int id)
        {
          
        }
        private AlbumDTO createAlbumDTO(Album album)
        {
            AlbumDTO albumDTO = new AlbumDTO()
            {
                Id = album.Id,
                Title = album.Title,
                ArtistName = album.AlbumArtist?.Name ?? "Unknown",
                MusicGenre = album.MusicGenre.ToString(),
                ReleaseYear = album.ReleaseYear,
                Stock = album.Stock
            };
            return albumDTO;
        }

    }

}

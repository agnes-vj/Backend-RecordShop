using Microsoft.EntityFrameworkCore;
using RecordShop.Model;

namespace RecordShop.Repository
{
    public interface IAlbumsRepository
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album FindAlbumById(int id);

    }
    public class AlbumsRepository : IAlbumsRepository
    {
        RecordShopDbContext _dbContext;
        public AlbumsRepository(RecordShopDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            IEnumerable<Album> albums;
            try
            {
               albums = _dbContext.Albums
                                  .Include(album => album.AlbumArtist);
            }
            catch (Exception ex)
            {
                throw new RecordShopException(ErrorStatus.Internal_Server_Error,ex.Message);
            }
            return albums;
                                            
        }

        public Album FindAlbumById(int id)
        {
            return _dbContext.Albums.Find(id);
        }
        public Album CreateAlbums(AlbumDTO albumDTO)
        {
            return null;
        }
        public Album UpdateAlbumById(int id)
        {
            return null;
        }
        public Album DeleteAlbumById(int id)
        {
            return null;
        }
    }

}

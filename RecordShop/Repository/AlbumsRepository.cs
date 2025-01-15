using Microsoft.EntityFrameworkCore;
using RecordShop.Model;

namespace RecordShop.Repository
{
    public interface IAlbumsRepository
    {
        public IEnumerable<Album> GetAllAlbums();

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
            return _dbContext.Albums
                             .Include(album => album.AlbumArtist);                             
        }

        public Album FindAlbumById(int id)
        {
            return null;
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

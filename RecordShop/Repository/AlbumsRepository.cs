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
                             .Include(album => album.AlbumArtist)
                             .ToList();
        }

    }

}

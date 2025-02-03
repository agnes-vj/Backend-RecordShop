using Microsoft.EntityFrameworkCore;
using RecordShop.Model;

namespace RecordShop.Repository
{
    public interface IAlbumsRepository
    {
        public List<Album> GetAllAlbums();
        public Album? FindAlbumById(int id);
        public Album? FindAlbumByTitleAndArtist(string title, string artistName);
        public Album CreateAlbum(Album album);
        public Album UpdateAlbum(Album album);
        public Album ReplaceAlbum(Album newAlbum);
        public void DeleteAlbum(Album album);

    }
    public class AlbumsRepository : IAlbumsRepository
    {
        RecordShopDbContext _dbContext;
        public AlbumsRepository(RecordShopDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public List<Album> GetAllAlbums()
        {
            return _dbContext.Albums
                             .Include(album => album.AlbumArtist)
                             .ToList();     
        }

        public Album? FindAlbumById(int id)
        {
            return _dbContext.Albums.Include(album => album.AlbumArtist).FirstOrDefault(album => album.Id == id);
        }

        public Album? FindAlbumByTitleAndArtist(string title, string artistName)
        {
            return _dbContext.Albums.FirstOrDefault(album => (album.Title == title && album.AlbumArtist.Name == artistName));
        }
        public Album CreateAlbum(Album album)
        {           
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
            return album;
        }
        public Album ReplaceAlbum(Album albumWithNewValues)
        {
            _dbContext.Update(albumWithNewValues);
            _dbContext.SaveChanges();

            return albumWithNewValues;
        }
        public void DeleteAlbum(Album album)
        {
            _dbContext.Albums.Remove(album);
            _dbContext.SaveChanges();
        }

        public Album UpdateAlbum(Album album)
        {
            throw new NotImplementedException();
        }
    }

}

using Microsoft.EntityFrameworkCore;
using RecordShop.Model;
using RecordShop.Repository;
using FluentAssertions;
namespace RecordStoreTests.RepositoryTest
{
    public class Tests
    {
        RecordShopDbContext _db;
        AlbumsRepository _albumsRepository;
        List<Artist> artists;
        List<Album> albums;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RecordShopDbContext>()
                                                    .UseInMemoryDatabase(databaseName: "TestRecordShopDatabase")
                                                    .Options;
            _db = new RecordShopDbContext(options);
            _albumsRepository = new(_db);
            artists = new()
                        {
                            new Artist(1,"The Beatles","Legendary British rock band."),
                            new Artist(2, "Taylor Swift","Award-winning pop and country music artist."),
                            new Artist(3, "Michael Jackson", "Known as the King of Pop, Michael Jackson was a global icon and music legend.")
                        };
            albums = new()
                {
                   new Album
                   { Id = 1, Title = "Abbey Road", ArtistId = 1, AlbumArtist = artists[0], MusicGenre = Genre.Rock, ReleaseYear = 1969, Stock = 10 },
                    new Album
                   { Id = 2, Title = "Let It Be", MusicGenre = Genre.Rock, AlbumArtist = artists[0], ReleaseYear = 1970, Stock = 40, ArtistId = 1 },
                   new Album
                   { Id = 3, Title = "1989", ArtistId = 2, AlbumArtist = artists[1], MusicGenre = Genre.Pop,ReleaseYear = 2014, Stock = 15},
                   new Album
                    { Id = 4, Title = "Thriller", ArtistId = 3, AlbumArtist = artists[2], MusicGenre = Genre.Pop,ReleaseYear = 1982 ,Stock = 10},
                   new Album
                   { Id = 5, Title = "Fearless", ArtistId = 2, AlbumArtist = artists[1], MusicGenre = Genre.Country, ReleaseYear = 2008, Stock = 55 }
                };

        }
        [TearDown]
        public void TearDown()
        {
            _db.Dispose();
        }

        [Test]
        public void GetAllAlbums_Returns_Albums()
        {
            //Arrange
            _db.Artists.AddRange(artists);
            _db.Albums.AddRange(albums);
            _db.SaveChanges();
            //Act
            var result = _albumsRepository.GetAllAlbums();

            //Assert
            Assert.That(result.Count, Is.EqualTo(5));
            result.Should().BeEquivalentTo(albums);
        }

        [Test]
        public void GetAllAlbums_Returns_Empty()
        {
            //Arrange
            var allAlbums = _db.Albums.ToList();
            _db.Albums.RemoveRange(allAlbums);

             var allArtists = _db.Artists.ToList();
             _db.Artists.RemoveRange(allArtists);

             _db.SaveChanges();
            //Act
            var result = _albumsRepository.GetAllAlbums();

            //Assert
            Assert.That(result.Count, Is.EqualTo(0));
            result.Should().BeEmpty();
        }

    }
}
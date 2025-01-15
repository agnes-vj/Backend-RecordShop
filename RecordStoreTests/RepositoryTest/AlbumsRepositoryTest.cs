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
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RecordShopDbContext>()
                                                    .UseInMemoryDatabase(databaseName: "TestRecordShopDatabase")
                                                    .Options;
            _db = new RecordShopDbContext(options);
            _albumsRepository = new(_db);
        }
        [TearDown]
        public void TearDown()
        {
            _db.Dispose();
        }

    //    [Test]
    //    public void GetAllAlbums()
    //    {
    //        //Arrange
    //        List<Album> albums = new List<Album>
    //        {
    //            new Album()
    //            {
    //                Title = "Harry's House",
    //                Artist = "Harry Styles",
    //                Genre = "Pop",
    //                ReleaseYear = 2022,
    //                Stock = 20
    //            },
    //            new Album()
    //            {
    //                Title = "Renaissance",
    //                Artist = "Beyoncé",
    //                Genre = "Pop/Dance",
    //                ReleaseYear = 2022,
    //                Stock = 18
    //            },
    //            new Album()
    //            {
    //                Title = "Midnights",
    //                Artist = "Taylor Swift",
    //                Genre = "Pop",
    //                ReleaseYear = 2022,
    //                Stock = 25
    //            },
    //            new Album()
    //            {
    //                Title = "The Greatest Showman (Original Soundtrack)",
    //                Artist = "Various Artists",
    //                Genre = "Soundtrack",
    //                ReleaseYear = 2017,
    //                Stock = 20
    //            },
    //            new Album()
    //            {
    //                Title = "Frozen II (Original Soundtrack)",
    //                Artist = "Various Artists",
    //                Genre = "Children's Music",
    //                ReleaseYear = 2019,
    //                Stock = 15
    //            }
    //        };
    //        _db.AddRange(albums);
    //        _db.SaveChanges();

    //        //Act
    //        var result = _albumsRepository.GetAllAlbums();

    //        //Assert
    //        result.Should().BeEquivalentTo(albums);
    //    }
    }
}
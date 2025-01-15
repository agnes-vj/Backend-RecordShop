using Microsoft.EntityFrameworkCore;
using Moq;
using RecordShop.Model;
using RecordShop.Repository;
using RecordShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Reflection;

namespace TestsRecordShop.ServiceTest
{
    internal class AlbumsServiceTest
    {

        Mock<IAlbumsRepository> _mockAlbumsRepository;
        AlbumsService _albumsService;
        List<AlbumDTO> expected;
        List<Artist> artists;
        List<Album> albums;

        [SetUp]
        public void Setup()
        {
            _mockAlbumsRepository = new Mock<IAlbumsRepository>();
            _albumsService = new AlbumsService(_mockAlbumsRepository.Object);
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

            expected = new List<AlbumDTO>
                {
                  new AlbumDTO()
                   { Id = 1, Title = "Abbey Road", ArtistName = "The Beatles", MusicGenre = "Rock", ReleaseYear = 1969, Stock = 10 },
                   new AlbumDTO
                   { Id = 2, Title = "Let It Be", MusicGenre = "Rock", ReleaseYear = 1970, Stock = 40, ArtistName = "The Beatles" },
                   new AlbumDTO
                   { Id = 3, Title = "1989", ArtistName = "Taylor Swift", MusicGenre = "Pop", ReleaseYear = 2014, Stock = 15},
                   new AlbumDTO
                    { Id = 4, Title = "Thriller", ArtistName = "Michael Jackson", MusicGenre = "Pop", ReleaseYear = 1982 ,Stock = 10},
                   new AlbumDTO
                   { Id = 5, Title = "Fearless", ArtistName ="Taylor Swift", MusicGenre = "Country", ReleaseYear = 2008, Stock = 55 }
                };
        }


        [Test]
        public void GetAllAlbums_Returns_AlbumDTO()
        {
            //Arrange
            _mockAlbumsRepository.Setup(repo => repo.GetAllAlbums()).Returns(albums);

            //Act
            var result = _albumsService.GetAllAlbums();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void GetAllAlbums_calls_Repo_Once()
        {
            //Arrange
            
            _mockAlbumsRepository.Setup(repo => repo.GetAllAlbums()).Returns(albums);

            //Act
            var result = _albumsService.GetAllAlbums();

            //Assert
            _mockAlbumsRepository.Verify(repo => repo.GetAllAlbums(),Times.Once);
        }
        [Test]
        public void createAlbumDTO_Returns_Correct_AlbumDTO()
        {
            //Arrange
            Album albumParameter = albums[0];
            AlbumDTO expectedAlbumDTO = expected[0];
            //Act
            var result = typeof(AlbumsService).GetMethod("createAlbumDTO", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(_albumsService, new Object[] { albumParameter });

            //Assert
            Assert.That(result, Is.InstanceOf<AlbumDTO>());
            result.Should().BeEquivalentTo(expectedAlbumDTO);



        }
    }
}


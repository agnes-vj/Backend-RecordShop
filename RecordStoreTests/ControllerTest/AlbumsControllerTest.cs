using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShop.Controllers;
using RecordShop.Model;
using RecordShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsRecordShop.ControllerTest
{
    internal class AlbumsControllerTest
    {
        Mock<IAlbumsService> _mockAlbumsService;
        AlbumsController _albumsController;
        List<AlbumDTO> expected;
        [SetUp]
        public void setup()
        {
            _mockAlbumsService = new Mock<IAlbumsService>();
            _albumsController = new AlbumsController(_mockAlbumsService.Object);
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
        public void GetAllAlbums_returns_200_StatusCode()
        {
            //Arrange
            _mockAlbumsService.Setup(service => service.GetAllAlbums()).Returns(expected);

            //Act
            var result = _albumsController.GetAllAlbums() as ObjectResult;

            //Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(200));

        }
    }
}

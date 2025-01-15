namespace RecordShop.Model
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public Artist AlbumArtist { get; set;}
        public Genre MusicGenre {get; set;} 
        public int ReleaseYear {get; set;}
        public int Stock {get; set;}
        public Album() : base()
        {

        }
        public Album(int id, string title, int artistId, Genre genre, int releaseYear, int stock)
        {
            Id = id;
            Title = title;
            ArtistId = artistId;
            MusicGenre = genre;
            ReleaseYear = releaseYear;
            Stock = stock;
        }
    }
}

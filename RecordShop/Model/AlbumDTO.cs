namespace RecordShop.Model
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public string MusicGenre { get; set; }
        public int ReleaseYear { get; set; }
        public int Stock { get; set; }
    }
}
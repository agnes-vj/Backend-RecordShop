namespace RecordShop.Model
{
    public class Artist
    {
        public Artist(int id, string name, string about)
        {
            Id = id;
            Name = name;
            About = about;    
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;

        public ICollection<Album> Albums { get; set; } = [];

    }
}
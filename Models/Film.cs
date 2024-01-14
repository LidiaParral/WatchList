namespace WatchList_Netflix.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int YearFilm { get; set; }
        public string Director { get; set; } = string.Empty;
        public string Actors { get; set; } = string.Empty;
    }
}

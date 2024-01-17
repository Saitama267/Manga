namespace Manga.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string MangaGenre { get; set; } 
        public bool IsOngoing { get; set; }
        public string Author { get; set; }
    }
}

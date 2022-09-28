namespace RentAMovie.Models
{
    public class MovieRole 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCharacter> MovieCharacters { get; set; } 
    }
}

using System.Text.Json.Serialization;

namespace DataBaseExample.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int PublishedYear { get; set; }

        //M-1
        [JsonIgnore]
        public Category? Category { get; set; } // Navigation property
        public int? CategoryId { get; set; } // Foreign key property

        public List<User> FavoriteByUsers { get; set; } = new(); // Many-to-Many relationship
    }
}

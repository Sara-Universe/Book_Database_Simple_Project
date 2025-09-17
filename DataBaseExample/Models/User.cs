namespace DataBaseExample.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<Book> FavoriteBooks { get; set; } = new List<Book>(); // Many-to-Many relationship
    }

}

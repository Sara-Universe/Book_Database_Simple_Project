namespace DataBaseExample.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        //1-M
        public List<Book> Books { get; set; } = new();
    }
}

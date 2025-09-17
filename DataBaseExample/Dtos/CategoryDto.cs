
namespace DataBaseExample.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<BookDto> Books { get; set; } = new(); // optional if you want some book info
    }
}

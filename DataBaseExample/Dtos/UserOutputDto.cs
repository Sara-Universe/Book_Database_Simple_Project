using DataBaseExample.Models;

namespace DataBaseExample.Dtos
{
    public class UserOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<BookDto> FavoriteBooks { get; set; } = new List<BookDto>();
    }
}

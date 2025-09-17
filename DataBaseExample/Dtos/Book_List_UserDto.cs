using DataBaseExample.Models;

namespace DataBaseExample.Dtos
{
    public class Book_List_UserDto
    {

        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int PublishedYear { get; set; }
        public int? CategoryId { get; set; }
        public List<AddUserDto> FavoriteByUsers { get; set; } = new();
    }
}

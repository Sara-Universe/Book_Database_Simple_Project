using DataBaseExample.Models;
using System.Text.Json.Serialization;

namespace DataBaseExample.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int PublishedYear { get; set; }
        public int? CategoryId { get; set; } // Foreign key property
    }
}

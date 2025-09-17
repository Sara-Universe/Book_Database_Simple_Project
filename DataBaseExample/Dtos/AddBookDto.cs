using DataBaseExample.Models;
using System.Text.Json.Serialization;

namespace DataBaseExample.Dtos
{
    public class AddBookDto
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int PublishedYear { get; set; }
        public int? CategoryId { get; set; } 
    }
}

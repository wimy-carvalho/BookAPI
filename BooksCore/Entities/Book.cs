using System.ComponentModel.DataAnnotations;

namespace BooksCore.Entities
{
    public class Book
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Editor { get; set; }

        [Required]
        public string Edition { get; set; }

        [Required]
        public BookDetail Details { get; set; }
    }
}
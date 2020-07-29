using System.ComponentModel.DataAnnotations;

namespace BooksCore.Entities
{
    public class BookDetail
    {
        [Required]
        public string ISBN;

        [Required]
        public string EditionYear;

        public string Language;
        public string Dimension;

        [Required]
        public string Pages;

        [Required]
        public string Style;
    }
}
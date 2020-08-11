using System.ComponentModel.DataAnnotations;

namespace BooksCore.Entities
{
    public class BookDetail
    {
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string EditionYear { get; set; }

        public string Language { get; set; }
        public string Dimension { get; set; }

        [Required]
        public string Pages { get; set; }

        [Required]
        public string Style { get; set; }

        public BookDetail(string iSBN, string editionYear, string language, string dimension, string pages, string style)
        {
            ISBN = iSBN;
            EditionYear = editionYear;
            Language = language;
            Dimension = dimension;
            Pages = pages;
            Style = style;
        }

        public BookDetail(string iSBN, string editionYear, string pages, string style)
        {
            ISBN = iSBN;
            EditionYear = editionYear;
            Pages = pages;
            Style = style;
        }
    }
}
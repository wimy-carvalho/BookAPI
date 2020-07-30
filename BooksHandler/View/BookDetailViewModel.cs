using System.ComponentModel.DataAnnotations;

namespace BooksHandler.View
{
    public class BookDetailViewModel
    {
        [Required]
        public string _isbn;

        [Required]
        public string _editionYear;

        public string _language;
        public string _dimension;

        [Required]
        public string _pages;

        [Required]
        public string _style;

        public BookDetailViewModel(string ISBN, string EditionYear, string Pages, string Style)
        {
            this._isbn = ISBN;
            this._editionYear = EditionYear;
            this._pages = Pages;
            this._style = Style;
        }

        public BookDetailViewModel(string ISBN, string EditionYear, string Pages, string Style, string Language, string Dimension)
        {
            this._isbn = ISBN;
            this._editionYear = EditionYear;
            this._pages = Pages;
            this._style = Style;
            this._language = Language;
            this._dimension = Dimension;
        }
    }
}
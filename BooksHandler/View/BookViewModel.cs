using System.ComponentModel.DataAnnotations;

namespace BooksHandler.View
{
    public class BookViewModel
    {
        [Required]
        public string _name { get; set; }

        [Required]
        public string _editor { get; set; }

        [Required]
        public string _edition { get; set; }

        [Required]
        public BookDetailViewModel _details { get; set; }

        public BookViewModel(string Name, string Editor, string Edition, BookDetailViewModel Details)
        {
            this._name = Name;
            this._editor = Editor;
            this._edition = Edition;
            this._details = Details;
        }
    }
}
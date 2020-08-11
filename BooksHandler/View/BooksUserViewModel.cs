using BooksCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace BooksHandler.View
{
    public class BooksUserViewModel
    {
        public string _id { get; set; }

        [Required]
        public string _user { get; set; }

        [Required]
        public Book[] _books { get; set; }

        public BooksUserViewModel(string User, Book[] Books)
        {
            this._user = User;
            this._books = Books;
        }

        public BooksUserViewModel(string ID, string User, Book[] Books)
        {
            this._id = ID;
            this._user = User;
            this._books = Books;
        }
    }
}
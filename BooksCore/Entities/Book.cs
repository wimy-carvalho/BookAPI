using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BooksCore.Entities
{
    public class Book
    {
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Required]
        public string _name { get; set; }

        [Required]
        public string _editor { get; set; }

        [Required]
        public string _edition { get; set; }

        [Required]
        public BookDetail _details { get; set; }

        public Book(string Name, string Editor, string Edition, BookDetail Details)
        {
            this._name = Name;
            this._editor = Editor;
            this._edition = Edition;
            this._details = Details;
        }

        public Book(string id, string Name, string Editor, string Edition, BookDetail Details)
        {
            this._id = id;
            this._name = Name;
            this._editor = Editor;
            this._edition = Edition;
            this._details = Details;
        }
    }
}
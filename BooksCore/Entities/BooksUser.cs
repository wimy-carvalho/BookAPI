using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BooksCore.Entities
{
    public class BooksUser
    {
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Required]
        public string _parentID { get; set; }

        [Required]
        public Book[] _books { get; set; }

        public BooksUser(string id, string userID, Book[] books)
        {
            _id = id;
            _parentID = userID;
            _books = books;
        }

        public BooksUser(string userID, Book[] books)
        {
            _parentID = userID;
            _books = books;
        }
    }
}
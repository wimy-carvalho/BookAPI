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

        public User _user { get; set; }

        public Book[] _books { get; set; }
    }
}
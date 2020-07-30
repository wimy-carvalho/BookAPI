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
        public User _user { get; set; }

        [Required]
        public Book[] _books { get; set; }
    }
}
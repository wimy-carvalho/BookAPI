using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BooksCore.Entities
{
    public class User
    {
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Profession { get; set; }

        [Required]
        public string Location { get; set; }

        public User(string name, DateTime birthday, string profession, string location)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Profession = profession;
            this.Location = location;
        }

        public User(string id, string name, DateTime birthday, string profession, string location)
        {
            this._id = id;
            this.Name = name;
            this.Birthday = birthday;
            this.Profession = profession;
            this.Location = location;
        }
    }
}
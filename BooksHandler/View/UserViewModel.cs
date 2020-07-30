using System;
using System.ComponentModel.DataAnnotations;

namespace BooksHandler.View
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Profession { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
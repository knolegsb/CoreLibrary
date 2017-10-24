using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLibrary.Entities
{
    public class Author
    {
        //public Author()
        //{
        //    Books = new List<Book>();
        //}

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Genre { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

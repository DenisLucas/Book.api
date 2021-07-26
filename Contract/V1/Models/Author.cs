using System.Collections.Generic;

namespace firstTUT.Data.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }

        public List<AuthorsToBooks> AuthorBook { get; set; }
    }
}
namespace firstTUT.Data.Models
{
    public class AuthorsToBooks
    {
        public int id { get; set; }
        
        public int AuthorId { get; set; }
        public Author Author {get; set;}

        public int BookId { get; set; }

        public Book Book { get; set; }


    }
}
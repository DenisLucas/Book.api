using System.Collections.Generic;

namespace firstTUT.Data.Models
{
    public class Publisher
    {
        public int id { get; set; }
        public string name { get; set;}
        
        public List<Book> Books { get; set; }
    }
}
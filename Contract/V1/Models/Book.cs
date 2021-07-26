using System;
using System.Collections.Generic;

namespace firstTUT.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public int ? Rate { get; set; }
        public string Genre { get; set; }
        public DateTime ? DateRead { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        public int ? PublisherId {get; set;}
        public Publisher publishers {get; set;}

        public List<AuthorsToBooks> AuthorBook {get; set;}
    }
}
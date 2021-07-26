using System;
using System.Collections.Generic;

namespace firstTUT.Data.Models.VModels
{
    public class VmBook
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public int ? Rate { get; set; }
        public string Genre { get; set; }
        public DateTime ? DateRead { get; set; }
        public string CoverUrl { get; set; }

        public int Publisherid { get; set; }
        public List<int> AuthorsId {get; set;}
    }
    public class VmBookWithAuthors
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public int ? Rate { get; set; }
        public string Genre { get; set; }
        public DateTime ? DateRead { get; set; }
        public string CoverUrl { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorsName { get; set; }
    }
}
using System.Collections.Generic;
using firstTUT.Data.Models;

namespace firstTUT.Data.VModels
{
    public class VmAuthor
    {
        public string FullName { get; set; }
    }
    public class VmAuthorWithBooks
    {
        public string FullName { get; set; }
        public List<string> BookName {get; set;}
    }

}
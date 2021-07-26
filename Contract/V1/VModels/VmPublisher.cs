using System.Collections.Generic;

namespace firstTUT.Data.VModels
{
    public class VmPublisher
    {
        public string name { get; set;}
    }

    public class VmPublisherBook
    {
        public string name { get; set;}
        public List<string> bookName {get; set;}
    }
}
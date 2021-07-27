using System.Linq;
using System.Threading.Tasks;
using firstTUT.Data.Models;
using firstTUT.Data.VModels;
using Microsoft.EntityFrameworkCore;
using my_Books.Data;

namespace firstTUT.Data.Services
{
    public class PublisherServices : IPublishers
    {
        private AppDbContext _context;
        public PublisherServices (AppDbContext context)
        {
            _context = context;
        }
        

        public async Task<bool> AddPublisher(VmPublisher publisher)
        {
            var _publisher = new Publisher()
            {
                name = publisher.name
            };
            await _context.AddAsync(_publisher);
            var update = await _context.SaveChangesAsync();
            return update > 0;
        }

        public async Task<VmPublisherBook> GetPublisherBookById(int publicid)
        {
            return await _context.publishers.Where(x => x.id == publicid).Select(x => new VmPublisherBook()
            {   
                name = x.name,
                bookName = x.Books.Select(x => x.Title).ToList()
            }).FirstOrDefaultAsync();
        }
    
    }
}
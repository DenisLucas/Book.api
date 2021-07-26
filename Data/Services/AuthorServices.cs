using System.Linq;
using System.Threading.Tasks;
using firstTUT.Data.Models;
using firstTUT.Data.VModels;
using Microsoft.EntityFrameworkCore;
using my_Books.Data;

namespace firstTUT.Data.Services
{
    public class AuthorServices : IAuthorServices
    {
        private AppDbContext _context;
        public AuthorServices (AppDbContext context)
        {
            _context = context;
        }
        

        public async Task<bool> AddAuthor(VmAuthor author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Add(_author);
            var update = await _context.SaveChangesAsync();
            return update > 0;
        }

        public async Task<VmAuthorWithBooks> GetAuthorWithBooksById(int id)
        {
            return await _context.Authors.Where(x => x.AuthorId == id).Select(y => new VmAuthorWithBooks() {
                FullName = y.FullName,
                BookName = y.AuthorBook.Select(x => x.Book.Title).ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteAuthor(int Authorid){
            var _Author = _context.Authors.FirstOrDefault(x => x.AuthorId == Authorid);
            _context.Authors.Remove(_Author);
            var update = await _context.SaveChangesAsync();
            return update > 0;
        }
    }
}
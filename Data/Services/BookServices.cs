using System;
using System.Collections.Generic;
using System.Linq;
using firstTUT.Data.Models;
using firstTUT.Data.Models.VModels;
using my_Books.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace firstTUT.Data.Services
{
    public class BookServices : IBookServices
    {
        private AppDbContext _context;
        public BookServices (AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBook(VmBook book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.Publisherid
            };
            await _context.Books.AddAsync(_book);
            var update = await _context.SaveChangesAsync();

            foreach (int auth in book.AuthorsId)
            {
                var authortobook = new AuthorsToBooks()
                {
                    AuthorId = auth,
                    BookId = _book.Id
                };
            

                await _context.BooksToAuthors.AddAsync(authortobook);
                await _context.SaveChangesAsync();
            }

            return update > 0;
        }

        public async Task<List<VmBookWithAuthors>> GetAllBooks()
        {
            return await _context.Books.Select(book => new VmBookWithAuthors(){
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                CoverUrl = book.CoverUrl,
                PublisherName = book.publishers.name,
                AuthorsName = book.AuthorBook.Select(n => n.Author.FullName).ToList()
            }).ToListAsync();

        }
        public async Task<VmBookWithAuthors> GetBookById(int Bookid)
        {
            return await _context.Books.Where(x => x.Id == Bookid).Select(book => new VmBookWithAuthors(){
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                CoverUrl = book.CoverUrl,
                PublisherName = book.publishers.name,
                AuthorsName = book.AuthorBook.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefaultAsync();
        }
        public async Task<List<VmBookWithAuthors>> GetBookByTitle(string title) 
        {
            return await _context.Books.Where(x => x.Title == title).Select(book => new VmBookWithAuthors(){
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                CoverUrl = book.CoverUrl,
                PublisherName = book.publishers.name,
                AuthorsName = book.AuthorBook.Select(n => n.Author.FullName).ToList()
            }).ToListAsync();
        
        }
        
        public async Task<bool> ChangeBook(int Bookid, VmBook book)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(x => x.Id == Bookid);
            _book.Title = book.Title;
            _book.Description = book.Description;
            _book.IsRead = book.IsRead;
            _book.Rate = book.IsRead ? book.Rate.Value : null;
            _book.Genre = book.Genre;
            _book.DateRead = book.IsRead ? book.DateRead.Value : null;
            _book.CoverUrl = book.CoverUrl;
            _book.PublisherId = book.Publisherid;

            var update = await _context.SaveChangesAsync();
            return update > 0;
        } 
        
        public async Task<bool> DeleteBook(int Bookid){
            var _book = await _context.Books.FirstOrDefaultAsync(x => x.Id == Bookid);
            _context.Books.Remove(_book);
            var update = await _context.SaveChangesAsync();
            return update > 0;
        }

        public async Task<bool> DeleteAllBooks() {
           var _books = _context.Books.ToList();
        
            _context.RemoveRange(_books);
            var update = await _context.SaveChangesAsync();
            return update > 0;

        }
    }
}

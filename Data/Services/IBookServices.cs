using System;
using System.Collections.Generic;
using firstTUT.Data.Models.VModels;
using System.Threading.Tasks;
namespace firstTUT.Data.Services
{
    public interface IBookServices
    {
        Task<List<VmBookWithAuthors>> GetAllBooks();
        Task<VmBookWithAuthors> GetBookById(int Bookid);
        Task<List<VmBookWithAuthors>> GetBookByTitle(string title);
        Task<bool> ChangeBook(int Bookid, VmBook book);
        Task<bool> DeleteBook(int Bookid);
        Task<bool> DeleteAllBooks();
        Task<bool> AddBook(VmBook book);

    }
}
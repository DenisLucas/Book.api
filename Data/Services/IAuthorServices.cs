using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using firstTUT.Data.VModels;

namespace firstTUT.Data.Services
{
    public interface IAuthorServices
    {
        Task<bool> AddAuthor(VmAuthor author);
        Task<VmAuthorWithBooks> GetAuthorWithBooksById(int id);
        Task<bool> DeleteAuthor(int Authorid);
    }
}
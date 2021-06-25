using System.Collections.Generic;
using BooksCatalog.API.Models;
using BooksCatalog.Domain.Books;

namespace BooksCatalog.API.Services.Contracts
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAll(Status bookStatus);
        void Add(AddBookRequest request);
    }
}
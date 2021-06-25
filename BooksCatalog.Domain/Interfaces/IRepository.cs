using System.Collections.Generic;
using BooksCatalog.Domain.Books;

namespace BooksCatalog.Domain.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetByStatus(Status status);
        Book GetById(int anId);
        void Add(Book entity);
        void SaveChanges();
    }
}
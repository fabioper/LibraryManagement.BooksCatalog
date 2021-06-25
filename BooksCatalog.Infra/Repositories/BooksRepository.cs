using System.Collections.Generic;
using System.Linq;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Repositories
{
    public class BooksRepository : IBookRepository
    {
        private readonly DbSet<Book> _books;
        private readonly BooksCatalogContext _context;

        public BooksRepository(BooksCatalogContext context)
        {
            _context = context;
            _books = context.Books;
        }
        
        public IEnumerable<Book> GetAll() => _books.AsNoTracking().ToList();

        public IEnumerable<Book> GetByStatus(Status status)
        {
            return _books.AsNoTracking()
                .Where(b => b.Status == status)
                .ToList();
        }

        public Book GetById(int anId) => _books.FirstOrDefault(b => b.Id == anId);

        public void Add(Book entity)
        {
            _books.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
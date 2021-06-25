using System.Collections.Generic;
using BooksCatalog.API.Models;
using BooksCatalog.API.Services.Contracts;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Interfaces;

namespace BooksCatalog.API.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _bookRepository;

        public BooksService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAll(bool? isAvailable)
        {
            return isAvailable.HasValue
                ? _bookRepository.GetByStatus(isAvailable.Value)
                : _bookRepository.GetAll();
        }

        public void Add(AddBookRequest request)
        {
            var book = new Book(request.Title, request.Description, request.Author);
            _bookRepository.Add(book);
            _bookRepository.SaveChanges();
        }
    }
}
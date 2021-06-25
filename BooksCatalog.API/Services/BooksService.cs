using System.Collections.Generic;
using BooksCatalog.API.Events;
using BooksCatalog.API.Models;
using BooksCatalog.API.Services.Contracts;
using BooksCatalog.Domain.Books;
using BooksCatalog.Domain.Interfaces;
using BooksCatalog.Infra.Messaging.Contracts;
using Microsoft.Extensions.Logging;

namespace BooksCatalog.API.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IServiceBus _serviceBus;
        private readonly ILogger<BooksService> _logger;

        public BooksService(IBookRepository bookRepository, IServiceBus serviceBus, ILogger<BooksService> logger)
        {
            _bookRepository = bookRepository;
            _serviceBus = serviceBus;
            _logger = logger;
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
            
            _serviceBus.Publish(new BookCreated(book.Id));
            _logger.LogInformation($"Book {book.Id} created");
        }
    }
}
using BooksCatalog.API.Consumers.Messages;
using BooksCatalog.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BooksCatalog.API.Consumers
{
    public class BookRentedConsumer : Consumer<BookRented>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BookRentedConsumer(IServiceScopeFactory serviceScopeFactory) : base("book-rented")
            => _serviceScopeFactory = serviceScopeFactory;

        public override void HandleMessage(BookRented message)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<BookRentedConsumer>>();
            var bookRepository = scope.ServiceProvider.GetRequiredService<IBookRepository>();

            var book = bookRepository.GetById(message.BookId);
            book.RentBook();
            bookRepository.SaveChanges();
            
            logger.LogInformation($"Book {message.BookId} rented");
        }
    }
}
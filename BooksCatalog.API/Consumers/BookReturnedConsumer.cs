using BooksCatalog.API.Consumers.Messages;
using BooksCatalog.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BooksCatalog.API.Consumers
{
    public class BookReturnedConsumer : Consumer<BookReturned>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BookReturnedConsumer(IServiceScopeFactory serviceScopeFactory) : base("book-returned")
            => _serviceScopeFactory = serviceScopeFactory;
        
        public override void HandleMessage(BookReturned message)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var logger = scope.ServiceProvider.GetRequiredService<ILogger<BookRentedConsumer>>();
            var bookRepository = scope.ServiceProvider.GetRequiredService<IBookRepository>();

            var book = bookRepository.GetById(message.BookId);
            book.ReturnBook();
            bookRepository.SaveChanges();
            
            logger.LogInformation($"Book {message.BookId} returned");
        }
    }
}
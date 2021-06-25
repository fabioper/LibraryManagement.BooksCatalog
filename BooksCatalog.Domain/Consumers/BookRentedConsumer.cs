using BooksCatalog.Domain.Consumers.Messages;
using BooksCatalog.Domain.Interfaces;

namespace BooksCatalog.Domain.Consumers
{
    public class BookRentedConsumer : EventConsumer<BookRented>
    {
        private readonly IBookRepository _repository;

        public BookRentedConsumer(IBookRepository repository) : base(queueName: "book-rented")
        {
            _repository = repository;
        }

        public override void HandleMessage(BookRented message)
        {
            var book = _repository.GetById(message.BookId);
            book.RentBook();
            _repository.SaveChanges();
        }
    }
}
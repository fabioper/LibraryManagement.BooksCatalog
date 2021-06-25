using BooksCatalog.Domain.Books;
using NUnit.Framework;

namespace BooksCatalog.Domain.Tests
{
    public class BookTests
    {
        [Test]
        public void RentBook_Should_Set_Book_As_Unavailable()
        {
            var book = new Book();
            book.RentBook();
            
            Assert.That(book.IsAvailable, Is.False);
        }

        [Test]
        public void ReturnBook_Should_Set_Book_As_Available()
        {
            var book = new Book();
            book.ReturnBook();
            
            Assert.That(book.IsAvailable, Is.True);
        }
    }
}
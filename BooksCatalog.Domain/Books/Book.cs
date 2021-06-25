namespace BooksCatalog.Domain.Books
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public void RentBook() => IsAvailable = false;
        public void ReturnBook() => IsAvailable = false;

        public Book(string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
            IsAvailable = true;
        }

        public Book() // EF required
        {
        }
    }
}
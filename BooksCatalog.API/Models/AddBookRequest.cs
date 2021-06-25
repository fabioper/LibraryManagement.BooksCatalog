namespace BooksCatalog.API.Models
{
    public class AddBookRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
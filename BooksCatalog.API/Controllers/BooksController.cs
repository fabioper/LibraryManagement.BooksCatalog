using BooksCatalog.API.Models;
using BooksCatalog.API.Services.Contracts;
using BooksCatalog.Domain.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BooksCatalog.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBooksService booksService, ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] Status bookStatus)
        {
            _logger.LogInformation("Retrieving books");
            var books = _booksService.GetAll(bookStatus);
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(AddBookRequest request)
        {
            _logger.LogInformation($"Creating a new book: {request.Title}");
            _booksService.Add(request);
            return Ok();
        }
    }
}
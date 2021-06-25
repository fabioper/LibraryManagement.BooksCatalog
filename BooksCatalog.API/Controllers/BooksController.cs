using BooksCatalog.API.Models;
using BooksCatalog.API.Services.Contracts;
using BooksCatalog.Domain.Books;
using Microsoft.AspNetCore.Mvc;

namespace BooksCatalog.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] Status bookStatus)
        {
            var books = _booksService.GetAll(bookStatus);
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Add(AddBookRequest request)
        {
            _booksService.Add(request);
            return Ok();
        }
    }
}
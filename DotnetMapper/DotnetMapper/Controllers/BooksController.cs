using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using DotnetMapper.Models;
using DotnetMapper.Services;
using StackExchange.Profiling;

namespace DotnetMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(BookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            object books = null;
            using (MiniProfiler.Current.Step("Get list"))
            {
                books = await _bookService.GetBooks();
            }
            return new ObjectResult(books);
        }

        // GET api/Books/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            object book;
            using (MiniProfiler.Current.Step("Get Item"))
            {
                book = await _bookService.GetBook(id);
                if (book == null)
                    return new NotFoundResult();
            }
            return new OkObjectResult(book);
        }

        // POST api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] BookViewModel bookViewModel)
        {
            Book book = _mapper.Map<Book>(bookViewModel);
            await _bookService.Create(book);
            return new OkObjectResult(book);
        }

        // PUT api/Books/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(
            string id, [FromBody] BookViewModel bookViewModel)
        {
            var bookFromDb = await _bookService.GetBook(id);

            if (bookFromDb == null)
                return new NotFoundResult();

            Book book = _mapper.Map<Book>(bookViewModel);
            book.Id = bookFromDb.Id;
            await _bookService.Update(book);

            return new OkObjectResult(book);
        }
    }
}

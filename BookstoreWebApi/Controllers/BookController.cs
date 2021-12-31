using Microsoft.AspNetCore.Mvc;
using BookstoreWebApi.Entity;
using System.Linq;
using System.Diagnostics;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookstoreWebApi.Application.BookOperations.Commands.CreateBook;
using BookstoreWebApi.Application.BookOperations.Commands.UpdateBook;
using BookstoreWebApi.Application.BookOperations.Queries.GetBook;
using AutoMapper;
using FluentValidation;
using BookstoreWebApi.Application.BookOperations.Commands.DeleteBook;

namespace BookstoreWebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookstoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookstoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery booksQuery = new GetBooksQuery(_context, _mapper);
            var result = booksQuery.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookQuery getBookQuery = new GetBookQuery(_context, _mapper);
            GetBookQueryValidator validator = new GetBookQueryValidator();
            BookViewModel vm;
            getBookQuery.BookId = id;

            validator.ValidateAndThrow(getBookQuery);
            vm = getBookQuery.Handle();

            return Ok(vm);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand bookCommand = new CreateBookCommand(_context, _mapper);
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            bookCommand.Model = newBook;

            validator.ValidateAndThrow(bookCommand);
            bookCommand.Handle();

            return Ok("Kitap basariyla eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();

            updateBookCommand.Model = updatedBook;
            updateBookCommand.BookId = id;

            validator.ValidateAndThrow(updateBookCommand);
            updateBookCommand.Handle();

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();

            deleteBookCommand.BookId = id;
            validator.ValidateAndThrow(deleteBookCommand);
            deleteBookCommand.Handle();

            return Ok("Kitap basariyla silindi");
        }
    }
}

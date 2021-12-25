using Microsoft.AspNetCore.Mvc;
using BookstoreWebApi.Entity;
using System.Linq;
using System.Diagnostics;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.BookOperations.GetBooks;
using BookstoreWebApi.BookOperations.CreateBook;
using BookstoreWebApi.BookOperations.UpdateBook;
using BookstoreWebApi.BookOperations.GetBook;
using AutoMapper;
using FluentValidation;
using BookstoreWebApi.BookOperations.DeleteBook;

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
            try
            {
                getBookQuery.BookId = id;
                validator.ValidateAndThrow(getBookQuery);
                vm = getBookQuery.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(vm);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommand bookCommand = new CreateBookCommand(_context, _mapper);
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            try
            {
                bookCommand.Model = newBook;
                validator.ValidateAndThrow(bookCommand);
                bookCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Kitap basariyla eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            try
            {
                updateBookCommand.Model = updatedBook;
                updateBookCommand.BookId = id;
                validator.ValidateAndThrow(updateBookCommand);
                updateBookCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            try
            {
                deleteBookCommand.BookId = id;
                validator.ValidateAndThrow(deleteBookCommand);
                deleteBookCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok("Kitap basariyla silindi");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using BookstoreWebApi.Entity;
using System.Linq;
using System.Diagnostics;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.BookOperations.GetBooks;
using BookstoreWebApi.BookOperations.CreateBook;
using BookstoreWebApi.BookOperations.UpdateBook;
using BookstoreWebApi.BookOperations.GetBook;

namespace BookstoreWebApi.Controllers {

    [ApiController]
    [Route("[controller]s")]
    public class BookController: ControllerBase {
        private readonly BookstoreDbContext _context;
        public BookController(BookstoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery booksQuery = new GetBooksQuery(_context);
            var result = booksQuery.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            GetBookQuery getBookQuery = new GetBookQuery(_context);
            BookViewModel vm;
            try
            {
                getBookQuery.BookId = id;
                vm = getBookQuery.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok(vm);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
           CreateBookCommand bookCommand = new CreateBookCommand(_context);
           bookCommand.Model= newBook;
           try
           {
                bookCommand.Handle();
           }
           catch (Exception ex)
           {
               return BadRequest(ex.Message);
           }
            return Ok("Kitap basariyla eklendi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody]UpdateBookModel updatedBook){
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
            try
            {
                 updateBookCommand.Model = updatedBook;
                 updateBookCommand.BookId = id;
                 updateBookCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            try
            {
                 deleteBookCommand.BookId = id;
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

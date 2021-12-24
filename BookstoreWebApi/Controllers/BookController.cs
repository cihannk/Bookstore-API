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
                 vm = getBookQuery.Handle(id);
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
                 updateBookCommand.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            Book deletingBook = _context.Books.SingleOrDefault(book => book.ID == id);
            if (deletingBook is null){
                return BadRequest();
            }
            _context.Books.Remove(deletingBook);
            _context.SaveChanges();
            return Ok();
        }
    }
}

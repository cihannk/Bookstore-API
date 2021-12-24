using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.BookOperations.CreateBook{
    public class CreateBookCommand {
        public CreateBookModel Model { get; set; }
        private readonly BookstoreDbContext _dbContext;
        public CreateBookCommand(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle() {
            Book book = _dbContext.Books.SingleOrDefault(book => book.Title == Model.Title);

            if (book is not null){
                throw new InvalidOperationException();
            }

            book = new Book();

            book.Title = Model.Title;
            book.GenreID = Model.GenreId;
            book.PublishDate= Model.PublishDate;
            book.PageCount = Model.PageCount;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        
    }
    public class CreateBookModel {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
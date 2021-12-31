using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.Application.BookOperations.Commands.CreateBook{
    public class CreateBookCommand {
        public CreateBookModel Model { get; set; }
        private readonly BookstoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle() {
            Book book = _dbContext.Books.SingleOrDefault(book => book.Title == Model.Title);

            if (book is not null){
                throw new InvalidOperationException("Eklemek istedigin kitap zaten var");
            }

            book = _mapper.Map<Book>(Model); //new Book();

            // book.Title = Model.Title;
            // book.GenreID = Model.GenreId;
            // book.PublishDate= Model.PublishDate;
            // book.PageCount = Model.PageCount;

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
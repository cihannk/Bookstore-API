using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookstoreWebApi.Application.BookOperations.Queries.GetBook{
    public class GetBookQuery{
        private readonly BookstoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookQuery(BookstoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookViewModel Handle(){
            Book book = _dbContext.Books.Include(x => x.Genre).Where(x => x.ID == BookId).FirstOrDefault();
            if (book is null){
                throw new InvalidOperationException("Kitap mevcut değil");
            }
            BookViewModel vm = _mapper.Map<BookViewModel>(book);
            return vm;
        }
        
    }
    public class BookViewModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string  Genre { get; set; }
    }
}
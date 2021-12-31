using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookstoreWebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookstoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookstoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x => x.Genre).OrderBy(book => book.ID).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            return vm;
        }

    }
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
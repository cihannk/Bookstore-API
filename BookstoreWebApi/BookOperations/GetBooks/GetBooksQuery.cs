using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.BookOperations.GetBooks
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
            var bookList = _dbContext.Books.OrderBy(book => book.ID).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);

            // foreach (var book in bookList)
            // {
            //     vm.Add(new BooksViewModel
            //     {
            //         Title = book.Title,
            //         PageCount = book.PageCount,
            //         PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //         Genre = ((GenreEnum)book.GenreID).ToString()
            //     });
            // }
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
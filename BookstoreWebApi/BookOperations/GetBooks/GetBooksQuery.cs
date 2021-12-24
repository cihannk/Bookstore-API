using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookstoreDbContext _dbContext;
        public GetBooksQuery(BookstoreDbContext context)
        {
            _dbContext = context;
        }
        public List<BooksViewModel> Handle()
        {
            List<BooksViewModel> vm = new List<BooksViewModel>();
            var bookList = _dbContext.Books.OrderBy(book => book.ID).ToList<Book>();

            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    Genre = ((GenreEnum)book.GenreID).ToString()
                });
            }
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
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.BookOperations.GetBook{
    public class GetBookQuery{
        private readonly BookstoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBookQuery(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BookViewModel Handle(){
            BookViewModel vm = new BookViewModel();
            Book book = _dbContext.Books.Where(x => x.ID == BookId).FirstOrDefault();
            if (book is null){
                throw new InvalidOperationException("Kitap mevcut değil");
            }
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            vm.Genre = ((GenreEnum)book.GenreID).ToString();
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
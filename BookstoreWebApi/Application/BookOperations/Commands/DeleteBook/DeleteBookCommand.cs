using BookstoreWebApi.DBOperations;

namespace BookstoreWebApi.Application.BookOperations.Commands.DeleteBook{
    public class DeleteBookCommand{
        private readonly BookstoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var book = _dbContext.Books.FirstOrDefault(x => x.ID == BookId);
            if (book is null){
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }

}
using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookstoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookstoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);
            if (author is null){
                throw new InvalidOperationException("Author veritabanında yok");
            }
            if (_context.Books.Any(x => x.AuthorId == AuthorId)){
                throw new InvalidOperationException("Authorun yayında kitabı var silinemez.");
            }
            
            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}
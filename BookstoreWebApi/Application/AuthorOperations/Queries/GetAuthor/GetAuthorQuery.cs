using AutoMapper;
using BookstoreWebApi.DBOperations;

namespace BookstoreWebApi.Application.AuthorOperations.Queries.GetAuthor
{
    public class GetAuthorQuery
    {
        private readonly BookstoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorQuery(BookstoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public AuthorViewModel Handle() {
            var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);
            Console.WriteLine(author);
            if (author is null){
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            return _mapper.Map<AuthorViewModel>(author);
        }
    }
    public class AuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
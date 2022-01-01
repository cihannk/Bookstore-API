using AutoMapper;
using BookstoreWebApi.DBOperations;

namespace BookstoreWebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IMapper _mapper;
        private readonly BookstoreDbContext _context;
        public GetAuthorsQuery(IMapper mapper, BookstoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList();
            return _mapper.Map<List<AuthorsViewModel>>(authors);
        }

    }
    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
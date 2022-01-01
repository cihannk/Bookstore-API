using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookstoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }
        public CreateAuthorCommand(BookstoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            var author = _context.Authors.FirstOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if (author is not null){
                throw new InvalidOperationException("Author zaten var");
            }

            Model.FirstName = Model.FirstName[0].ToString().ToUpper() + Model.FirstName.Substring(1, Model.FirstName.Length - 1).ToLower();
            Model.LastName = Model.LastName[0].ToString().ToUpper() + Model.LastName.Substring(1, Model.LastName.Length - 1).ToLower();

            _context.Add(_mapper.Map<Author>(Model));
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
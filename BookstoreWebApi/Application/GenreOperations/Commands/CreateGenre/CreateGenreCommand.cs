using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly BookstoreDbContext _context;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(IMapper mapper, BookstoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            var genre = _context.Genres.FirstOrDefault(x => x.Name == Model.Name);
            if (genre is not null){
                throw new InvalidOperationException("Kategori zaten varç");
            }
            _context.Genres.Add(_mapper.Map<Genre>(Model));
            _context.SaveChanges();
        }
    }
    public class CreateGenreModel{
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
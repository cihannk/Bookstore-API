using AutoMapper;
using BookstoreWebApi.DBOperations;
using BookstoreWebApi.Entity;

namespace BookstoreWebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly BookstoreDbContext _context;
        public int GenreId {get;set;}
        public DeleteGenreCommand(IMapper mapper, BookstoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == GenreId);
            if (genre is null){
                throw new InvalidOperationException("Genre yok");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();

        }
    }
}
using AutoMapper;
using BookstoreWebApi.DBOperations;

namespace BookstoreWebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookstoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMapper mapper, BookstoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<GenresViewModel> Handle(){
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> genresViewModels = _mapper.Map<List<GenresViewModel>>(genres);
            return genresViewModels;
        }
    }
    public class GenresViewModel{
        public int Id { get; set; }
         public string Name { get; set; }
    }
}
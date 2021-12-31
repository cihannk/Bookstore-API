using System.Data;
using FluentValidation;

namespace BookstoreWebApi.Application.GenreOperations.Queries.GetGenre
{
    public class GetGenreQueryValidator : AbstractValidator<GetGenreQuery>
    {
        public GetGenreQueryValidator()
        {   
            RuleFor(query => query.GenreId).GreaterThan(0);
            RuleFor(query => query.GenreId).NotNull();
        }
    }
}
using FluentValidation;

namespace BookstoreWebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.GenreId).GreaterThan(0);
            RuleFor(x => x.GenreId).NotEmpty();
        }
    }
}
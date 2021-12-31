using FluentValidation;

namespace BookstoreWebApi.Application.GenreOperations.Commands.UpdateGenre {
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {
        public UpdateGenreCommandValidator()
        {
            RuleFor(genreCommand => genreCommand.GenreId).GreaterThan(0);
            RuleFor(genreCommand => genreCommand.Model.isActive).NotEmpty();
            RuleFor(genreCommand => genreCommand.Model.Name).MinimumLength(3).When(x => x.Model.Name.Trim() != String.Empty);
        }
    }
}
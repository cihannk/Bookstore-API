using FluentValidation;

namespace BookstoreWebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(3);
            RuleFor(x => x.Model.isActive).NotEmpty().When(x => x.Model.isActive != false);
        }
    }
}
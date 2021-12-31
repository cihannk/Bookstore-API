using FluentValidation;

namespace BookstoreWebApi.Application.BookOperations.Commands.CreateBook{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>{
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).MinimumLength(3);
            //RuleFor(command => command.Model.Title).NotNull();
        }
    }
}
using FluentValidation;

namespace BookstoreWebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.Title).MinimumLength(3);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate.Date).LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(command => command.Model.GenreID).GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).GreaterThan(0);
        }
    }
}
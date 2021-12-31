using FluentValidation;

namespace BookstoreWebApi.Application.BookOperations.Commands.DeleteBook{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
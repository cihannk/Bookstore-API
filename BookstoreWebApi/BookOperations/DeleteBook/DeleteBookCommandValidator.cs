using BookstoreWebApi.BookOperations.UpdateBook;
using FluentValidation;

namespace BookstoreWebApi.BookOperations.DeleteBook{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
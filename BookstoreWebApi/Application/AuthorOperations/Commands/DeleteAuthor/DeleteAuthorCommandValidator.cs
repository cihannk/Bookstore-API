using FluentValidation;

namespace BookstoreWebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator :AbstractValidator<DeleteAuthorCommand> {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0).NotEmpty();
        }
    }
}
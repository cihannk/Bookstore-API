using FluentValidation;

namespace BookstoreWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand> {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.LastName).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.BirthDate.Date).LessThanOrEqualTo(DateTime.Now.Date).NotEmpty();
        }
    }
}
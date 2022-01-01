using FluentValidation;

namespace BookstoreWebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand> {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.LastName).MinimumLength(3).NotEmpty();
            RuleFor(x => x.Model.BirthDate.Date).LessThanOrEqualTo(DateTime.Now.Date).NotEmpty();
            RuleFor(x => x.AuthorId).GreaterThan(0).NotEmpty();
        }
    }
}
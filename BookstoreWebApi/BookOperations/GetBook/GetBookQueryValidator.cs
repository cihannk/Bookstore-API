using FluentValidation;

namespace BookstoreWebApi.BookOperations.GetBook
{
    public class GetBookQueryValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
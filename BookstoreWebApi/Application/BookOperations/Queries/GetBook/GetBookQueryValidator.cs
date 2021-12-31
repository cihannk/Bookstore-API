using FluentValidation;

namespace BookstoreWebApi.Application.BookOperations.Queries.GetBook
{
    public class GetBookQueryValidator : AbstractValidator<GetBookQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
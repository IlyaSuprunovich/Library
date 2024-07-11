using FluentValidation;

namespace Library.Application.Libraries.Queries.Book.GetBookByISBN
{
    public class GetBookByISBNQueryValidator : AbstractValidator<GetBookByISBNQuery>
    {
        public GetBookByISBNQueryValidator()
        {
            RuleFor(bookDetailsQuery =>
                bookDetailsQuery.ISBN)
                .NotEqual(string.Empty);
        }
    }
}

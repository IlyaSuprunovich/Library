using FluentValidation;

namespace Library.Application.Libraries.Queries.Author.GetAllAuthorBooks
{
    public class GetAllAuthorBookQueryValidator : AbstractValidator<GetAllAuthorBookQuery>
    {
        public GetAllAuthorBookQueryValidator()
        {
            RuleFor(authorBooksQuery =>
                authorBooksQuery.AuthorId)
                .NotEqual(Guid.Empty);
        }
    }
}

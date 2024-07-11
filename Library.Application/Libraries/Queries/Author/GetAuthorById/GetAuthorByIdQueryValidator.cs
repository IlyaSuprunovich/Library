using FluentValidation;

namespace Library.Application.Libraries.Queries.Author.GetAuthorDetails
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(authorDetailsQuery =>
                authorDetailsQuery.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

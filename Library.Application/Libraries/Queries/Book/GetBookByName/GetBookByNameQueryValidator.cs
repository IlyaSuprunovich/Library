using FluentValidation;

namespace Library.Application.Libraries.Queries.Book.GetBookByName
{
    public class GetBookByNameQueryValidator : AbstractValidator<GetBookByNameQuery>
    {
        public GetBookByNameQueryValidator()
        {
            RuleFor(bookQuery =>
                bookQuery.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}

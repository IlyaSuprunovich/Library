using FluentValidation;

namespace Library.Application.Libraries.Queries.LibraryUser.GetTakenBooks
{
    public class GetTakenBooksListQueryValidator : AbstractValidator<GetTakenBooksListQuery>
    {
        public GetTakenBooksListQueryValidator()
        {
            RuleFor(takenBooksListQuery =>
                takenBooksListQuery.Id)
                    .NotEqual(Guid.Empty);
        }
    }
}

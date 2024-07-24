using FluentValidation;

namespace Library.Application.Libraries.Queries.Image.GetImageById
{
    public class GetImageByIdQueryValidator : AbstractValidator<GetImageByIdQuery>
    {
        public GetImageByIdQueryValidator()
        {
            RuleFor(getImageQuery =>
                getImageQuery.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

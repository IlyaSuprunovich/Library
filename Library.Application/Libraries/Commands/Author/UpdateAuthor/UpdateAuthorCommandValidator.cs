using FluentValidation;

namespace Library.Application.Libraries.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(updateAuthorCommand =>
               updateAuthorCommand.Author.Id)
               .NotEqual(Guid.Empty);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Author.Name)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Author.Surname)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Author.DateOfBirth)
                .NotEmpty();

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Author.Country)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Author.Books)
                .NotEmpty();
        }
    }
}

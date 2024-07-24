using FluentValidation;

namespace Library.Application.Libraries.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Author.Name)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Author.Surname)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Author.DateOfBirth)
                .NotEmpty();

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Author.Country)
                .NotEmpty()
                .MaximumLength(20);
        }

    }
}

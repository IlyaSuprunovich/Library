using FluentValidation;

namespace Library.Application.Libraries.Commands.Author.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Name)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Surname)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(createAuthorCommand =>
                createAuthorCommand.DateOfBirth)
                .NotEmpty();

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Country)
                .NotEmpty()
                .MaximumLength(20);
        }

    }
}

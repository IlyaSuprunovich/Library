using FluentValidation;

namespace Library.Application.Libraries.Commands.Book.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(createBookCommand =>
                createBookCommand.ISBN)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(createBookCommand =>
                createBookCommand.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(createBookCommand =>
                createBookCommand.Genre)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(createBookCommand =>
                createBookCommand.Description)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(createBookCommand =>
                createBookCommand.AuthorId)
                .NotEqual(Guid.Empty);
        }
    }
}

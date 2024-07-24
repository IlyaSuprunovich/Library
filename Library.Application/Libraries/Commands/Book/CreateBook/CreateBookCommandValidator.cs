using FluentValidation;

namespace Library.Application.Libraries.Commands.Book.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(createBookCommand =>
                createBookCommand.Book.ISBN)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(createBookCommand =>
                createBookCommand.Book.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(createBookCommand =>
                createBookCommand.Book.Genre)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(createBookCommand =>
                createBookCommand.Book.Description)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(createBookCommand =>
                createBookCommand.Book.AuthorId)
                .NotEqual(Guid.Empty);

            RuleFor(createBookCommand =>
                createBookCommand.Book.File)
                .NotEmpty();
        }
    }
}

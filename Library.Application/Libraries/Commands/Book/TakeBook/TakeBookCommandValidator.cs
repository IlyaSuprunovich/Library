using FluentValidation;

namespace Library.Application.Libraries.Commands.Book.TakeBook
{
    public class TakeBookCommandValidator : AbstractValidator<TakeBookCommand>
    {
        public TakeBookCommandValidator()
        {
            RuleFor(takeBookCommand =>
                takeBookCommand.Id)
                .NotEqual(Guid.Empty);

            RuleFor(takeBookCommand =>
                takeBookCommand.LibraryUserId)
                .NotEqual(Guid.Empty);
        }
    }
}

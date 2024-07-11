using FluentValidation;

namespace Library.Application.Libraries.Commands.Book.ReturnBook
{
    public class ReturnBookCommandValidator : AbstractValidator<ReturnBookCommand>
    {
        public ReturnBookCommandValidator()
        {
            RuleFor(returnBookCommand =>
                returnBookCommand.Id)
                .NotEqual(Guid.Empty);

            RuleFor(returnBookCommand =>
                returnBookCommand.LibraryUserId)
                .NotEqual(Guid.Empty);
        }
    }
}

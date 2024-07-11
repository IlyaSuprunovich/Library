using FluentValidation;

namespace Library.Application.Libraries.Commands.Book.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(deleteBookCommand =>
                deleteBookCommand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

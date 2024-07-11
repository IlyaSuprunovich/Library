using FluentValidation;

namespace Library.Application.Libraries.Commands.Author.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(deleteAuthorCommand =>
                deleteAuthorCommand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

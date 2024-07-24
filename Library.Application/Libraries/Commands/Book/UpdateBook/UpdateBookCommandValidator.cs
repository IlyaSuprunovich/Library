using FluentValidation;
using Library.Application.Libraries.Commands.Author.UpdateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Book.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.Book.Id)
                .NotEqual(Guid.Empty);

            RuleFor(updateBookCommand =>
                updateBookCommand.Book.ISBN)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(updateBookCommand =>
                updateBookCommand.Book.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(updateBookCommand =>
                updateBookCommand.Book.Genre)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(updateBookCommand =>
                updateBookCommand.Book.Description)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(updateBookCommand =>
                updateBookCommand.Book.AuthorId)
                .NotEqual(Guid.Empty);

            RuleFor(updateBookCommand =>
                updateBookCommand.Book.File)
                .NotEmpty();
        }
    }
}

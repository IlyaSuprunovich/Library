using FluentValidation;
using Library.Application.Commands.UpdateBook;
using Library.Application.Libraries.Commands.UpdateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator() 
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.Id)
                .NotEqual(Guid.Empty);

            RuleFor(updateBookCommand =>
                updateBookCommand.ISBN)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(updateBookCommand =>
                updateBookCommand.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(updateBookCommand =>
                updateBookCommand.Genre)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(updateBookCommand =>
                updateBookCommand.Description)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(updateBookCommand =>
                updateBookCommand.Author)
                .NotEmpty();

            RuleFor(updateBookCommand =>
                updateBookCommand.AuthorId)
                .NotEqual(Guid.Empty);
        }
    }
}

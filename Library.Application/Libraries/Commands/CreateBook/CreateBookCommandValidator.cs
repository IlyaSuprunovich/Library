using FluentValidation;
using Library.Application.Commands.CreateBook;
using Library.Application.Libraries.Commands.CreateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.CreateBook
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
                createBookCommand.Author)
                .NotEmpty();

            RuleFor(createBookCommand =>
                createBookCommand.AuthorId)
                .NotEqual(Guid.Empty);
        }
    }
}

using FluentValidation;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Book.TakeBook
{
    public class TakeBookCommandValidator : AbstractValidator<TakeBookCommand>
    {
        public TakeBookCommandValidator()
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.Id)
                .NotEqual(Guid.Empty);


        }
    }
}

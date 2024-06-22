using FluentValidation;
using Library.Application.Libraries.Commands.Book.TakeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Book.ReturnBook
{
    public class ReturnBookCommandValidator : AbstractValidator<ReturnBookCommand>
    {
        public ReturnBookCommandValidator()
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.Id)
                .NotEqual(Guid.Empty);


        }
    }
}

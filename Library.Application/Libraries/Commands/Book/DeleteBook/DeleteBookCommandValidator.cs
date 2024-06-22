﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Book.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(deleteBookCommand =>
                deleteBookCommand.Id)
                .NotEqual(Guid.Empty);

            RuleFor(deleteBookCommand =>
                deleteBookCommand.AuthorId)
                .NotEqual(Guid.Empty);
        }
    }
}
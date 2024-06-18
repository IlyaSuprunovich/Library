using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.DeleteAuthor
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

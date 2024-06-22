using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(updateAuthorCommand =>
               updateAuthorCommand.Id)
               .NotEqual(Guid.Empty);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Name)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Surname)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.DateOfBirth)
                .NotEmpty();

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Country)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Books)
                .NotEmpty();
        }
    }
}

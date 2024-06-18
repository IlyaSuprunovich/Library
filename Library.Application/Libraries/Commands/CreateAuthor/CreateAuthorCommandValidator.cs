using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator() 
        {
            
            RuleFor(createAuthorCommand =>
                createAuthorCommand.Name)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Surname)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(createAuthorCommand =>
                createAuthorCommand.DateOfBirth)
                .NotEmpty();

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Country)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(createAuthorCommand =>
                createAuthorCommand.Books)
                .NotEmpty();
        }

    }
}

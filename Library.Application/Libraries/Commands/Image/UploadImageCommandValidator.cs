using FluentValidation;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Image
{
    internal class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
    {
        public UploadImageCommandValidator()
        {
            RuleFor(uploadImageCommand =>
                uploadImageCommand.File)
                .NotEmpty();

            RuleFor(uploadImageCommand =>
               uploadImageCommand.BookId)
               .NotEqual(Guid.Empty);
        }
    }
}

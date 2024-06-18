using FluentValidation;
using Library.Application.Commands.DeleteBook;
using Library.Application.Libraries.Queries.GetLibraryDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetBookDetails
{
    public class GetBookDetailsQueryValidator : AbstractValidator<GetBookDetailsQuery>
    {
        GetBookDetailsQueryValidator() 
        {
            RuleFor(bookDetailsQuery =>
                bookDetailsQuery.Id)
                .NotEqual(Guid.Empty);

            RuleFor(bookDetailsQuery =>
                bookDetailsQuery.AuthorId)
                    .NotEqual(Guid.Empty);
        }  
    }
}

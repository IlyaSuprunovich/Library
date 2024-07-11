using FluentValidation;
using Library.Application.Libraries.Commands.Book.DeleteBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookDetails
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(bookDetailsQuery =>
                bookDetailsQuery.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

using FluentValidation;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.TakeBook
{
    public class TakeBookQueryValidator : AbstractValidator<TakeBookQuery>
    {
        public TakeBookQueryValidator()
        {
            RuleFor(takeBookQuery =>
                takeBookQuery.Id)
                .NotEqual(Guid.Empty);

            /*RuleFor(bookDetailsQuery =>
                bookDetailsQuery.AuthorId)
                    .NotEqual(Guid.Empty);*/
        }
    }
}

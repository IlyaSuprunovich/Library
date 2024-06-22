using FluentValidation;
using Library.Application.Libraries.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookByISBN
{
    public class GetBookByISBNQueryValidator : AbstractValidator<GetBookByISBNQuery>
    {
        public GetBookByISBNQueryValidator()
        {
            RuleFor(bookDetailsQuery =>
                bookDetailsQuery.ISBN)
                .NotEqual(string.Empty);

            /*RuleFor(bookDetailsQuery =>
                bookDetailsQuery.AuthorId)
                    .NotEqual(Guid.Empty);*/
        }
    }
}

using FluentValidation;
using Library.Application.Libraries.Queries.Book.GetBookList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Author.GetAllAuthorBooks
{
    public class GetAllBookQueryValidator : AbstractValidator<GetAllAuthorBookQuery>
    {
        public GetAllBookQueryValidator()
        {
            RuleFor(bookListQuery =>
                bookListQuery.UserId)
                    .NotEqual(Guid.Empty);
        }
    }
}

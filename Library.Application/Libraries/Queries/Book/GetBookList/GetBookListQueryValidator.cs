using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookList
{
    public class GetBookListQueryValidator : AbstractValidator<GetBookListQuery>
    {
        public GetBookListQueryValidator()
        {
            RuleFor(bookListQuery =>
                bookListQuery.AuthorId)
                    .NotEqual(Guid.Empty);
        }
    }
}

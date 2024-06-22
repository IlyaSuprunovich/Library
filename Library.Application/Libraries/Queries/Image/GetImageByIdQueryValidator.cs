using FluentValidation;
using Library.Application.Libraries.Queries.Book.TakeBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Image
{
    public class GetImageByIdQueryValidator : AbstractValidator<GetImageByIdQuery>
    {
        public GetImageByIdQueryValidator()
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

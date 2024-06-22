using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Author.GetAuthorList
{
    public class GetAuthorListQueryValidator : AbstractValidator<GetAuthorListQuery>
    {
        public GetAuthorListQueryValidator()
        {
            RuleFor(authorListQuery =>
                authorListQuery.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

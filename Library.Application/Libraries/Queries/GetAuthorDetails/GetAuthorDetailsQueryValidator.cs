using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQueryValidator : AbstractValidator<GetAuthorDetailsQuery>
    {
        public GetAuthorDetailsQueryValidator() 
        {
            RuleFor(authorDetailsQuery =>
                authorDetailsQuery.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

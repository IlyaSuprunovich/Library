using FluentValidation;
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
            RuleFor(getImageQuery =>
                getImageQuery.Id)
                .NotEqual(Guid.Empty);
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Image
{
    public class GetImageByIdQuery : IRequest<Domain.Image>
    {
        public Guid Id { get; set; }

        public GetImageByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

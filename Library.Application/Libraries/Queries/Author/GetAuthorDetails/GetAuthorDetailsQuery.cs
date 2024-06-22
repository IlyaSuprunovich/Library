using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Author.GetAuthorDetails
{
    public class GetAuthorDetailsQuery : IRequest<AuthorDetailsVm>
    {
        public Guid Id { get; set; }
    }
}

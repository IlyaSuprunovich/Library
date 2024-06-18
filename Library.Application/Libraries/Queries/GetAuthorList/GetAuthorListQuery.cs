using Library.Application.Libraries.Queries.GetBookList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<AuthorListVm>
    {
        public Guid Id { get; set; }
    }
}

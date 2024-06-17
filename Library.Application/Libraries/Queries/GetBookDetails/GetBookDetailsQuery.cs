using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetLibraryDetails
{
    public class GetBookDetailsQuery : IRequest<BookDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookList
{
    public class GetBookListQuery : IRequest<BookListVm>
    {
        public Guid AuthorId { get; set; }
    }
}

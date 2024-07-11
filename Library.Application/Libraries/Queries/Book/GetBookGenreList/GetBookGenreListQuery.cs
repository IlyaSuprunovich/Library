using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookGenreList
{
    public class GetBookGenreListQuery : IRequest<BookGenreListVm>
    {
    }
}

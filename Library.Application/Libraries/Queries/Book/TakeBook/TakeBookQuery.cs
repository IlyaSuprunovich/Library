using Library.Application.Libraries.Queries.Book.GetBookDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.TakeBook
{
    public class TakeBookQuery : IRequest<TakeBookVm>
    {
        public Guid Id { get; set; }
        public Guid NumberLibraryTicket { get; set; }
    }
}


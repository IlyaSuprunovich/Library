using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.Book.ReturnBook
{
    public class ReturnBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid NumberReaderTicket { get; set; }
    }
}

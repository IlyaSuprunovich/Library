using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

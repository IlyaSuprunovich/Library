using Library.Application.Libraries.Commands.Book.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Libraries.Commands.Book.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public UpdateBookRequestDto Book { get; set; }
    }
}

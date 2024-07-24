using Library.Application.Libraries.Commands.Book.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Libraries.Commands.Book.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public CreateBookRequestDto Book { get; set; }
    }
}
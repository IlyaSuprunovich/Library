using MediatR;

namespace Library.Application.Libraries.Commands.Book.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

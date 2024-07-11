using MediatR;

namespace Library.Application.Libraries.Commands.Book.ReturnBook
{
    public class ReturnBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid LibraryUserId { get; set; }
    }
}

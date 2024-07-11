using MediatR;

namespace Library.Application.Libraries.Commands.Book.TakeBook
{
    public class TakeBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid LibraryUserId { get; set; }
    }
}

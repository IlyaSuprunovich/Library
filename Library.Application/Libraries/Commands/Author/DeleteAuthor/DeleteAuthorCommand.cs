using MediatR;

namespace Library.Application.Libraries.Commands.Author.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

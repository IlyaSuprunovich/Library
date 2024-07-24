using Library.Application.Libraries.Commands.Author.DTO;
using MediatR;

namespace Library.Application.Libraries.Commands.Author.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        public UpdateAuthorRequestDto Author { get; set; }
    }
}

using Library.Application.Libraries.Queries.Image.DTO;
using MediatR;

namespace Library.Application.Libraries.Queries.Image.GetImageById
{
    public class GetImageByIdQuery : IRequest<ImageResponseDto>
    {
        public Guid Id { get; set; }

        public GetImageByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

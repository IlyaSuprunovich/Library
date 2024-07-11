using MediatR;

namespace Library.Application.Libraries.Queries.Image
{
    public class GetImageByIdQuery : IRequest<Domain.Image>
    {
        public Guid Id { get; set; }

        public GetImageByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}

using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Queries.Image.DTO;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Queries.Image.GetImageById
{
    public class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageResponseDto>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetImageByIdQueryHandler(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<ImageResponseDto> Handle(GetImageByIdQuery request, 
            CancellationToken cancellationToken)
        {
            Domain.Entities.Image? image = await _imageRepository.GetByIdAsync(request.Id, cancellationToken);
            if (image is not { })
                throw new NotFoundException(nameof(Domain.Entities.Image), request.Id);

            return _mapper.Map<ImageResponseDto>(image);    
        }
    }

}

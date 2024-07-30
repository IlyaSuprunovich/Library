using AutoMapper;
using Library.Application.Common.Mappings;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Libraries.Commands.Image.DTO
{
    public class UploadImageRequestDto : IMapWith<Domain.Entities.Image>
    {
        public IFormFile File { get; set; }
        public Guid BookId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UploadImageRequestDto, Domain.Entities.Image>()
                .ForMember(image => image.FileName,
                    x => x.MapFrom(imageDto => imageDto.File.FileName))
                .ForMember(image => image.ContentType,
                    x => x.MapFrom(imageDto => imageDto.File.ContentType));
        }
    }
}

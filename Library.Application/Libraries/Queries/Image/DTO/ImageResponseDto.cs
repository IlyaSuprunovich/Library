using AutoMapper;
using Library.Application.Common.Mappings;

namespace Library.Application.Libraries.Queries.Image.DTO
{
    public class ImageResponseDto : IMapWith<Domain.Entities.Image>
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Image, ImageResponseDto>()
                .ForMember(bookVm => bookVm.Id,
                    x => x.MapFrom(book => book.Id))
                .ForMember(bookVm => bookVm.FileName,
                    x => x.MapFrom(book => book.FileName))
                .ForMember(bookVm => bookVm.Path,
                    x => x.MapFrom(book => book.Path))
                .ForMember(bookVm => bookVm.ContentType,
                    x => x.MapFrom(book => book.ContentType));
        }
    }
}

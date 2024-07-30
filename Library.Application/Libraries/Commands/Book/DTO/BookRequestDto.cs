using AutoMapper;
using Library.Application.Common.Mappings;
using Microsoft.AspNetCore.Http;

namespace Library.Application.Libraries.Commands.Book.DTO
{
    public class BookRequestDto : IMapWith<Domain.Entities.Book>
    {
        public Guid? Id { get; set; } = Guid.Empty;
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public IFormFile File { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookRequestDto, Domain.Entities.Book>()
                 .ForMember(book => book.Id,
                    x => x.MapFrom(bookDto => bookDto.Id))
                 .ForMember(book => book.ISBN,
                    x => x.MapFrom(bookDto => bookDto.ISBN))
                 .ForMember(book => book.Name,
                    x => x.MapFrom(bookDto => bookDto.Name))
                 .ForMember(book => book.Genre,
                    x => x.MapFrom(bookDto => bookDto.Genre))
                 .ForMember(book => book.Description,
                    x => x.MapFrom(bookDto => bookDto.Description))
                 .ForMember(book => book.AuthorId,
                    x => x.MapFrom(bookDto => bookDto.AuthorId));
        }
    }
}

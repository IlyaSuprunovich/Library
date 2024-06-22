using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Commands.Book.CreateBook;
using Library.Domain;

namespace Library.WebApi.Models
{
    public class CreateBookDto : IMapWith<CreateBookCommand>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(bookCommand => bookCommand.ISBN,
                    x => x.MapFrom(bookDto => bookDto.ISBN))
                .ForMember(bookCommand => bookCommand.Name,
                    x => x.MapFrom(bookDto => bookDto.Name))
                .ForMember(bookCommand => bookCommand.Genre,
                    x => x.MapFrom(bookDto => bookDto.Genre))
                .ForMember(bookCommand => bookCommand.Description,
                    x => x.MapFrom(bookDto => bookDto.Description))
                .ForMember(bookCommand => bookCommand.Author,
                    x => x.MapFrom(bookDto => bookDto.Author))
                .ForMember(bookCommand => bookCommand.AuthorId,
                    x => x.MapFrom(bookDto => bookDto.AuthorId));
        }
    }
}

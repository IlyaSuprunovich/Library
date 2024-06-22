using AutoMapper;
using Library.Application.Libraries.Commands.Book.UpdateBook;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Commands.Author.UpdateAuthor;
using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Domain;

namespace Library.WebApi.Models
{
    public class UpdateAuthorDto : IMapWith<UpdateAuthorCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public ICollection<Book> Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Id,
                    x => x.MapFrom(authorDto => authorDto.Id))
                .ForMember(authorCommand => authorCommand.Name,
                    x => x.MapFrom(authorDto => authorDto.Name))
                .ForMember(authorCommand => authorCommand.Surname,
                    x => x.MapFrom(authorDto => authorDto.Surname))
                .ForMember(authorCommand => authorCommand.DateOfBirth,
                    x => x.MapFrom(authorDto => authorDto.DateOfBirth))
                .ForMember(authorCommand => authorCommand.Country,
                    x => x.MapFrom(authorDto => authorDto.Country))
                .ForMember(authorCommand => authorCommand.Books,
                    x => x.MapFrom(authorDto => authorDto.Books));
        }
    }
}

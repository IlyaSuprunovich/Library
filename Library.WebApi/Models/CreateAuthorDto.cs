using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Commands.Author.CreateAuthor;
using Library.Application.Libraries.Commands.Author.UpdateAuthor;
using Library.Domain;

namespace Library.WebApi.Models
{
    public class CreateAuthorDto : IMapWith<CreateAuthorCommand>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        //public ICollection<Book> Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Name,
                    x => x.MapFrom(authorDto => authorDto.Name))
                .ForMember(authorCommand => authorCommand.Surname,
                    x => x.MapFrom(authorDto => authorDto.Surname))
                .ForMember(authorCommand => authorCommand.DateOfBirth,
                    x => x.MapFrom(authorDto => authorDto.DateOfBirth))
                .ForMember(authorCommand => authorCommand.Country,
                    x => x.MapFrom(authorDto => authorDto.Country));
                /*.ForMember(authorCommand => authorCommand.Books,
                    x => x.MapFrom(authorDto => authorDto.Books));*/
        }
    }
}

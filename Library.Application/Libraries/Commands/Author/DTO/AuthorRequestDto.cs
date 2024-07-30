using AutoMapper;
using Library.Application.Common.Mappings;

namespace Library.Application.Libraries.Commands.Author.DTO
{
    public class AuthorRequestDto : IMapWith<Domain.Entities.Author>
    {
        public Guid? Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public ICollection<Domain.Entities.Book>? Books { get; set; } = null;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AuthorRequestDto, Domain.Entities.Author>()
                 .ForMember(authorDto => authorDto.Id,
                    x => x.MapFrom(author => author.Id))
                .ForMember(authorDto => authorDto.Name,
                    x => x.MapFrom(author => author.Name))
                .ForMember(authorDto => authorDto.Surname,
                    x => x.MapFrom(author => author.Surname))
                .ForMember(authorDto => authorDto.DateOfBirth,
                    x => x.MapFrom(author => author.DateOfBirth))
                .ForMember(authorDto => authorDto.Country,
                    x => x.MapFrom(author => author.Country))
                .ForMember(authorDto => authorDto.Books,
                    x => x.MapFrom(author => author.Books));
        }
    }
}

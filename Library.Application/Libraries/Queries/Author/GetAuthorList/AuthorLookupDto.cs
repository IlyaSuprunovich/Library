using AutoMapper;
using Library.Application.Common.Mappings;

namespace Library.Application.Libraries.Queries.Author.GetAuthorList
{
    public class AuthorLookupDto : IMapWith<Domain.Author>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Domain.Book>? Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Author, AuthorLookupDto>()
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

using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Author.GetAuthorList
{
    public class AuthorLookupDto : IMapWith<Domain.Author>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Author, AuthorLookupDto>()
                .ForMember(authorDto => authorDto.Id,
                    x => x.MapFrom(author => author.Id))
                .ForMember(authorDto => authorDto.Name,
                    x => x.MapFrom(author => author.Name));
        }
    }
}

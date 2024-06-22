using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Queries.Book.GetBookList;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Author.GetAllAuthorBooks
{
    public class AllAuthorBookLookupDto : IMapWith<Domain.Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Book, AllAuthorBookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                    x => x.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Name,
                    x => x.MapFrom(book => book.Name))
                .ForMember(bookDto => bookDto.AuthorId,
                    x => x.MapFrom(book => book.AuthorId));
        }
    }
}

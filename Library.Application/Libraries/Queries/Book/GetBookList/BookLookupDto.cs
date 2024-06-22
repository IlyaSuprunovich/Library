using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.GetBookList
{
    public class BookLookupDto : IMapWith<Domain.Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Book, BookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                    x => x.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Name,
                    x => x.MapFrom(book => book.Name));
        }
    }
}

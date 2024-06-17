using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetBookList
{
    public class BookLookupDto : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                    x => x.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Name,
                    x => x.MapFrom(note => note.Name));
        }
    }
}

using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.GetLibraryDetails
{
    public class BookDetailsVm : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsVm>()
                .ForMember(bookVm => bookVm.ISBN,
                    x => x.MapFrom(note => note.ISBN))
                .ForMember(bookVm => bookVm.Name,
                    x => x.MapFrom(note => note.Name))
                .ForMember(bookVm => bookVm.Genre,
                    x => x.MapFrom(note => note.Genre))
                .ForMember(bookVm => bookVm.Description,
                    x => x.MapFrom(note => note.Description));
        }
    }
}

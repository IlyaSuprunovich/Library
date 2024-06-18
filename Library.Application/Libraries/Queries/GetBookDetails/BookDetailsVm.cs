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
                    x => x.MapFrom(book => book.ISBN))
                .ForMember(bookVm => bookVm.Name,
                    x => x.MapFrom(book => book.Name))
                .ForMember(bookVm => bookVm.Genre,
                    x => x.MapFrom(book => book.Genre))
                .ForMember(bookVm => bookVm.Description,
                    x => x.MapFrom(book => book.Description));
        }
    }
}

using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Queries.Book.GetBookDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Libraries.Queries.Book.TakeBook
{
    public class TakeBookVm : IMapWith<Domain.Book>
    {
        public Guid Id { get; set; }
        public Guid NumberReaderTicket { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Book, TakeBookVm>()
                .ForMember(bookVm => bookVm.Id,
                    x => x.MapFrom(book => book.Id))
                .ForMember(bookVm => bookVm.NumberReaderTicket,
                    x => x.MapFrom(book => book.NumberReaderTicket));
        }
    }
}

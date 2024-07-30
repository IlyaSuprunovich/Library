using AutoMapper;
using Library.Domain.Entities;

namespace Library.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, Book>()
                .ForMember(book => book.ISBN,
                    x => x.MapFrom(book => book.ISBN))
                .ForMember(book => book.Name,
                    x => x.MapFrom(book => book.Name))
                .ForMember(book => book.Genre,
                    x => x.MapFrom(book => book.Genre))
                .ForMember(book => book.Description,
                    x => x.MapFrom(book => book.Description))
                .ForMember(book => book.AuthorId,
                    x => x.MapFrom(book => book.AuthorId))
                .ForMember(book => book.ImageId,
                    x => x.MapFrom(book => book.ImageId))
                .ForMember(book => book.LibraryUserId,
                    x => x.Ignore())
                .ForMember(book => book.IsBookInLibrary,
                    x => x.Ignore())
                .ForMember(book => book.TimeOfTake,
                    x => x.Ignore())
                .ForMember(book => book.TimeOfReturn,
                    x => x.Ignore());
        }
    }
}

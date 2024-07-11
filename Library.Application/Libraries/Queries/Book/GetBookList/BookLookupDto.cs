using AutoMapper;
using Library.Application.Common.Mappings;

namespace Library.Application.Libraries.Queries.Book.GetBookList
{
    public class BookLookupDto : IMapWith<Domain.Book>
    {
        public Guid Id { get; set; }
         public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Domain.Author Author { get; set; }
        public Domain.Image Image { get; set; }
        public bool IsBookInLibrary { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Book, BookLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                    x => x.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.ISBN,
                    x => x.MapFrom(book => book.ISBN))
                .ForMember(bookDto => bookDto.Name,
                    x => x.MapFrom(book => book.Name))
                .ForMember(bookDto => bookDto.Genre,
                    x => x.MapFrom(book => book.Genre))
                .ForMember(bookDto => bookDto.Description,
                    x => x.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.Author,
                    x => x.MapFrom(book => book.Author))
                .ForMember(bookDto => bookDto.Image,
                    x => x.MapFrom(book => book.Image))
                .ForMember(bookDto => bookDto.IsBookInLibrary,
                    x => x.MapFrom(book => book.IsBookInLibrary));
        }
    }
}

using AutoMapper;
using Library.Application.Common.Mappings;

namespace Library.Application.Libraries.Queries.Book.GetBookByName
{
    public class BookByNameLookupDto : IMapWith<Domain.Book>
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Domain.Author Author { get; set; }
        public Domain.Image Image { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Book, BookByNameLookupDto>()
                .ForMember(bookDto => bookDto.Id,
                    x => x.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.ISBN,
                    x => x.MapFrom(book => book.ISBN))
                .ForMember(bookDto => bookDto.Name,
                    x => x.MapFrom(book => book.Name))
                .ForMember(bookDto => bookDto.Genre,
                    x => x.MapFrom(book => book.Genre))
                .ForMember(bookDto => bookDto.Description,
                    x => x.MapFrom(book => book.Description));
        }
    }
}

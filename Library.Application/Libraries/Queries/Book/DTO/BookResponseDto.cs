using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Queries.Author.DTO;
using Library.Application.Libraries.Queries.Image.DTO;
using Library.Application.Libraries.Queries.LibraryUser.DTO;

namespace Library.Application.Libraries.Queries.Book.DTO
{
    public class BookResponseDto : IMapWith<Domain.Entities.Book>
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsBookInLibrary { get; set; }
        public AuthorResponseDto Author { get; set; }
        public ImageResponseDto Image { get; set; }
        public LibraryUserResponseDto? LibraryUser { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Book, BookResponseDto>()
                .ForMember(bookVm => bookVm.ISBN,
                    x => x.MapFrom(book => book.ISBN))
                .ForMember(bookVm => bookVm.Name,
                    x => x.MapFrom(book => book.Name))
                .ForMember(bookVm => bookVm.Genre,
                    x => x.MapFrom(book => book.Genre))
                .ForMember(bookVm => bookVm.Description,
                    x => x.MapFrom(book => book.Description))
                .ForMember(bookVm => bookVm.Author,
                    x => x.MapFrom(book => book.Author))
                .ForMember(bookVm => bookVm.Image,
                    x => x.MapFrom(book => book.Image))
                .ForMember(bookVm => bookVm.IsBookInLibrary,
                    x => x.MapFrom(book => book.IsBookInLibrary))
                .ForMember(bookVm => bookVm.LibraryUser,
                    x => x.MapFrom(book => book.LibraryUser));
        }
    }
}

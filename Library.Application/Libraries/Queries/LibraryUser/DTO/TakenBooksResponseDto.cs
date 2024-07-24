using AutoMapper;
using Library.Application.Common.Mappings;

namespace Library.Application.Libraries.Queries.LibraryUser.DTO
{
    public class TakenBooksResponseDto : IMapWith<Domain.Entities.Book>
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public Domain.Entities.Author Author { get; set; }
        public Domain.Entities.Image Image { get; set; }
        public Domain.Entities.LibraryUser LibraryUser { get; set; }
        public bool IsBookInLibrary { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Book, TakenBooksResponseDto>()
                .ForMember(bookVm => bookVm.Id,
                    x => x.MapFrom(book => book.Id))
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

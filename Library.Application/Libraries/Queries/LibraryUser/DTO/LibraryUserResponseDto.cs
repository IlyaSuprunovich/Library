using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Libraries.Queries.Book.DTO;

namespace Library.Application.Libraries.Queries.LibraryUser.DTO
{
    public class LibraryUserResponseDto : IMapWith<Domain.Entities.LibraryUser>
    {
        public Guid Id { get; set; }
        public ICollection<BookResponseDto>? TakenBooks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.LibraryUser, LibraryUserResponseDto>()
                .ForMember(bookVm => bookVm.Id,
                    x => x.MapFrom(book => book.Id))
                .ForMember(bookVm => bookVm.TakenBooks,
                    x => x.MapFrom(book => book.TakenBooks));
        }
    }
}

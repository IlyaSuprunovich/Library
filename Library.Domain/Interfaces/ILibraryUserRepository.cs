using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface ILibraryUserRepository
    {
        Task<IList<Book>> GetBooksAsync(Guid id, CancellationToken cancellationToken);
        Task<LibraryUser> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}

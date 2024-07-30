using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface ILibraryUserRepository : IRepository<LibraryUser>
    {
        Task<IList<Book>> GetBooksAsync(Guid id, CancellationToken cancellationToken);
    }
}

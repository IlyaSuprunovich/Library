using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetByIsbnAsync(string isbn, CancellationToken cancellationToken);
        Task<Book> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<IList<string>> GetGenreList(CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetListAsync(CancellationToken cancellationToken);
        Task TakeAsync(Guid bookId, Guid userId, CancellationToken cancellationToken);
        Task ReturnAsync(Guid bookId, Guid userId, CancellationToken cancellationToken);
    }
}

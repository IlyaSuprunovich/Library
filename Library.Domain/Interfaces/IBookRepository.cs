using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Book> GetByIsbnAsync(string isbn, CancellationToken cancellationToken);
        Task<Book> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<IList<string>> GetGenreList(CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetListAsync(CancellationToken cancellationToken);
        Task TakeAsync(Guid bookId, Guid userId, CancellationToken cancellationToken);
        Task ReturnAsync(Guid bookId, Guid userId, CancellationToken cancellationToken);
        Task AddAsync(Book entity, CancellationToken cancellationToken);
        Task UpdateAsync(Book entity, CancellationToken cancellationToken);
        void Delete(Book entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        IQueryable<Author> GetList(CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetBooksAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Author entity, CancellationToken cancellationToken);
        Task UpdateAsync(Author entity, CancellationToken cancellationToken);
        void Delete(Author author);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> HasDbAuthor(Author author, CancellationToken cancellationToken);
    }
}

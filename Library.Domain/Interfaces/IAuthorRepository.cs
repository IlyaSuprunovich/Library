using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IQueryable<Author> GetList(CancellationToken cancellationToken);
        Task<IQueryable<Book>> GetBooksAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> HasDbAuthor(Author author, CancellationToken cancellationToken);
    }
}

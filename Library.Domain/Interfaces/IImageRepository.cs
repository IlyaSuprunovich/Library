using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(Image entity, CancellationToken cancellationToken);
        void Delete(Image entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

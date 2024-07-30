using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public ImageRepository(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddAsync(Image entity, CancellationToken cancellationToken)
        {
            await _libraryDbContext.Images.AddAsync(entity, cancellationToken);
        }

        public async Task<Image> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Image? image = await _libraryDbContext.Images.FirstOrDefaultAsync(b =>
                b.Id == id, cancellationToken);

            if (image is not { })
                throw new NotFoundException(nameof(Author), id);

            return image;
        }

        public void Delete(Image entity) => _libraryDbContext.Images.Remove(entity);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Image entity, CancellationToken cancellationToken)
        {
            if (await _libraryDbContext.Images.AsNoTracking().AnyAsync(i => i.Id == entity.Id))
                _libraryDbContext.Images.Update(entity);
        }
    }
}

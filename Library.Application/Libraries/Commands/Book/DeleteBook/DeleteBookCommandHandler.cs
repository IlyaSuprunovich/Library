using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IImageRepository _imageRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IImageRepository imageRepository)
        {
            _bookRepository = bookRepository;
            _imageRepository = imageRepository;
        }
           
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Book? entity = await _bookRepository.GetByIdAsync(request.Id,
                cancellationToken); 

            if (entity is not { })
                throw new NotFoundException(nameof(Book), request.Id);
            
            if(entity.Image is { })
                File.Delete(entity.Image.Path);

            _imageRepository.Delete(entity.Image);
            _bookRepository.Delete(entity);
            await _bookRepository.SaveChangesAsync(cancellationToken);
        }
    }
}

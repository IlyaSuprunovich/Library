using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Commands.Image.UploadImage;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IMediator _mediator;

        public UpdateBookCommandHandler(IBookRepository bookRepository, 
            IImageRepository imageRepository, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _imageRepository = imageRepository;
            _mediator = mediator;
        }
            

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Book? entity = await _bookRepository.GetByIdAsync(request.Book.Id, 
                cancellationToken); 

            if (entity is not { })
                throw new NotFoundException(nameof(Book), request.Book.Id);

            Guid oldImageId = (Guid)entity.ImageId;
            Domain.Entities.Image? oldImage = await _imageRepository.GetByIdAsync(oldImageId,
                cancellationToken);

            UploadImageCommand imageCommand = new()
            {
                Image = new()
                {
                    File = request.Book.File,
                    BookId = entity.Id
                }
            };

            Guid imageId = await _mediator.Send(imageCommand, cancellationToken);

            Domain.Entities.Book book = new()
            {
                Id = request.Book.Id,
                ISBN = request.Book.ISBN,
                Name = request.Book.Name,
                Genre = request.Book.Genre,
                Description = request.Book.Description,
                AuthorId = request.Book.AuthorId
            };
            
            await _bookRepository.UpdateAsync(book, cancellationToken);
            _imageRepository.Delete(oldImage);
            await _bookRepository.SaveChangesAsync(cancellationToken);
        }
    }
}

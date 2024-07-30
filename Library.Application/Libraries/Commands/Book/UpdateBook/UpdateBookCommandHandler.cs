using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, 
            IImageRepository imageRepository, IMediator mediator, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _imageRepository = imageRepository;
            _mediator = mediator;
            _mapper = mapper;
        }
            

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Book book = _mapper.Map<Domain.Entities.Book>(request.Book);
            Domain.Entities.Book? existingBook = await _bookRepository.GetByIdAsync(book.Id, 
                cancellationToken); 

            if (existingBook is not { })
                throw new NotFoundException(nameof(Book), book.Id);

            Guid oldImageId = (Guid)existingBook.ImageId;
            Domain.Entities.Image? oldImage = await _imageRepository.GetByIdAsync(oldImageId,
                cancellationToken);

            UploadImageCommand imageCommand = new()
            {
                Image = new()
                {
                    File = request.Book.File,
                    BookId = existingBook.Id
                }
            };

            Guid imageId = await _mediator.Send(imageCommand, cancellationToken);
            book.ImageId = imageId;

            
            await _bookRepository.UpdateAsync(book, cancellationToken);
            _imageRepository.Delete(oldImage);
            await _bookRepository.SaveChangesAsync(cancellationToken);
        }
    }
}

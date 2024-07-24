using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Commands.Image.UploadImage;
using Library.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Libraries.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMediator _mediator;

        public CreateBookCommandHandler(IAuthorRepository authorRepository, 
            IBookRepository bookRepository, IMediator mediator)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mediator = mediator;
        }


        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Author? author = await _authorRepository.GetByIdAsync(request.Book.AuthorId, 
                cancellationToken);

            if(author is not { })
                throw new NotFoundException(nameof(Domain.Entities.Author), author.Id);
            
            Domain.Entities.Book? book = await _bookRepository.GetByNameAsync(request.Book.Name,
                cancellationToken);

            if(book?.AuthorId == request.Book.AuthorId)
                throw new AlreadyExists(nameof(Domain.Entities.Book), book.Id);

            if (book is not { })
            {
                book = new Domain.Entities.Book
                {
                    Id = Guid.NewGuid(),
                    ISBN = request.Book.ISBN,
                    Name = request.Book.Name,
                    Genre = request.Book.Genre,
                    Description = request.Book.Description,
                    Author = author,
                    AuthorId = request.Book.AuthorId
                };
                await _bookRepository.AddAsync(book, cancellationToken);
                await _bookRepository.SaveChangesAsync(cancellationToken);
            }

            UploadImageCommand imageCommand = new()
            {
                Image = new()
                {
                    File = request.Book.File,
                    BookId = book.Id
                }
            };

            Guid imageId = await _mediator.Send<Guid>(imageCommand, cancellationToken);

            await _bookRepository.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }


}

using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Libraries.Commands.Book.DTO;
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
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IAuthorRepository authorRepository, 
            IBookRepository bookRepository, IMediator mediator, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Book book = _mapper.Map<Domain.Entities.Book>(request.Book);
            Domain.Entities.Author? author = await _authorRepository.GetByIdAsync(book.AuthorId, 
                cancellationToken);

            if(author is not { })
                throw new NotFoundException(nameof(Domain.Entities.Author), book.AuthorId);
            
            Domain.Entities.Book? existingBook = await _bookRepository.GetByNameAsync(book.Name,
                cancellationToken);

            if(existingBook?.AuthorId == book?.AuthorId)
                throw new AlreadyExists(nameof(Domain.Entities.Book), existingBook.AuthorId);

            if (existingBook is not { })
            {
                book.Id = Guid.NewGuid();
                book.Author = author;
                book.AuthorId = author.Id;

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

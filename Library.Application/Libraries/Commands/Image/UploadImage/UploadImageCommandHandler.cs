using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Domain.Interfaces;
using MediatR;

namespace Library.Application.Libraries.Commands.Image.UploadImage
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Guid>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper; 

        public UploadImageCommandHandler(IImageRepository imageRepository,
            IBookRepository bookRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            if (request.Image.File == null || request.Image.File.Length == 0)
                throw new Exception("Invalid file.");

            Domain.Entities.Book? book = await _bookRepository.GetByIdAsync(request.Image.BookId,
                cancellationToken);

            if (book is not { })
                throw new NotFoundException(nameof(Domain.Entities.Book), request.Image.BookId);

            if (File.Exists(book?.Image?.Path))
                File.Delete(book.Image.Path);

            string[] currentDirectory = Directory.GetCurrentDirectory().Split('\\');
            currentDirectory[currentDirectory.Length - 1] = "Library.Persistence\\Image\\";
            string path = Path.Combine(currentDirectory);

            Domain.Entities.Image newImage = _mapper.Map<Domain.Entities.Image>(request.Image);
            newImage.Path = $"{path}{newImage.FileName}";


            await _imageRepository.AddAsync(newImage, cancellationToken);

            book.ImageId = newImage.Id;
            book.Image = newImage;

            await _imageRepository.SaveChangesAsync(cancellationToken);

            using (FileStream fileStream = new($"{newImage.Path}", FileMode.Create))
            {
                await request.Image.File.CopyToAsync(fileStream, cancellationToken);
            }

            return newImage.Id;
        }
    }
}

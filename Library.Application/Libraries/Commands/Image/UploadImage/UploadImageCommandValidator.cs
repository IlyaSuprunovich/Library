using FluentValidation;

namespace Library.Application.Libraries.Commands.Image.UploadImage
{
    internal class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
    {
        public UploadImageCommandValidator()
        {
            RuleFor(uploadImageCommand =>
                uploadImageCommand.Image.File)
                .NotEmpty();

            RuleFor(uploadImageCommand =>
               uploadImageCommand.Image.BookId)
               .NotEqual(Guid.Empty);
        }
    }
}

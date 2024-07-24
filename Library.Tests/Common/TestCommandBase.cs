using Library.Persistence;
using Library.Persistence.Repositories;
using MediatR;
using Moq;

namespace Library.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly LibraryDbContext Context;
        protected readonly AuthorRepository AuthorRepository;
        protected readonly BookRepository BookRepository;
        protected readonly ImageRepository ImageRepository;
        protected readonly IMediator Mediator;

        public TestCommandBase()
        {
            Context = LibraryContextFactory.Create();
            AuthorRepository = new AuthorRepository(Context);
            BookRepository = new BookRepository(Context);
            ImageRepository = new ImageRepository(Context);
            Mediator = Mock.Of<IMediator>();
        }

        public void Dispose()
        {
            LibraryContextFactory.Destroy(Context);
        }
    }
}

using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Interfaces;
using Library.Persistence;
using Library.Persistence.Repositories;
using MediatR;
using Moq;
using System.Reflection;

namespace Library.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly LibraryDbContext Context;
        protected readonly AuthorRepository AuthorRepository;
        protected readonly BookRepository BookRepository;
        protected readonly ImageRepository ImageRepository;
        protected readonly IMediator Mediator;
        protected readonly IMapper Mapper;

        public TestCommandBase()
        {
            Context = LibraryContextFactory.Create();
            
            
            ImageRepository = new ImageRepository(Context);
            Mediator = Mock.Of<IMediator>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                cfg.AddProfile(new AssemblyMappingProfile(typeof(ILibraryDbContext).Assembly));
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
            BookRepository = new BookRepository(Context, Mapper);
            AuthorRepository = new AuthorRepository(Context, Mapper);
        }

        public void Dispose()
        {
            LibraryContextFactory.Destroy(Context);
        }
    }
}

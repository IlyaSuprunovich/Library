using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Interfaces;
using Library.Persistence;
using Library.Persistence.Repositories;

namespace Library.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public LibraryDbContext Context;
        public IMapper Mapper;
        public AuthorRepository AuthorRepository;
        public BookRepository BookRepository;

        public QueryTestFixture()
        {
            Context = LibraryContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(ILibraryDbContext).Assembly));
            });

            Mapper = configurationProvider.CreateMapper();
            AuthorRepository = new(Context);
            BookRepository = new(Context);
        }

        public void Dispose() 
        {
            LibraryContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

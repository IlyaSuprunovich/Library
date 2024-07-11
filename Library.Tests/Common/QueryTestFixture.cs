using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Interfaces;
using Library.Persistence;

namespace Library.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public LibraryDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = LibraryContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(ILibraryDbContext).Assembly));
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() 
        {
            LibraryContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

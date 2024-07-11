namespace Library.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext libraryDbContext)
        {
            libraryDbContext.Database.EnsureCreated();
        }
    }
}

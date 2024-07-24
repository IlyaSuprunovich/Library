namespace Library.Domain.Entities
{
    public class LibraryUser
    {
        public Guid Id { get; set; }
        public virtual ICollection<Book>? TakenBooks { get; set; }
    }
}

namespace Library.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public virtual Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public bool? IsBookInLibrary { get; set; } = true; 
        public DateTime? TimeOfTake { get; set; }
        public DateTime? TimeOfReturn { get; set; }
        public virtual Image? Image { get; set; }
        public Guid ImageId { get; set; }
        public virtual LibraryUser? LibraryUser { get; set; }
        public Guid? LibraryUserId { get; set; }
        public int CountBook { get; set; }
    }
}

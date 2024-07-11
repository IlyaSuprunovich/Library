namespace Library.Domain
{
    public class Image
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public virtual Book? Book { get; set; }
        public Guid? BookId { get; set; }
    }
}

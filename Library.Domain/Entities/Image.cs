namespace Library.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
    }
}

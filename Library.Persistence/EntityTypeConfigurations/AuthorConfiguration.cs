using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class AuthorConfiguration  : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.Id);

            builder.HasIndex(author => author.Id)
                   .IsUnique();

            builder.Property(author => author.Name)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(author => author.Surname)
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(author => author.DateOfBirth)
                   .IsRequired();

            builder.Property(author => author.Country)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.HasMany(author => author.Books)
                   .WithOne(book => book.Author)
                   .HasForeignKey(book => book.AuthorId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new Author
               {
                   Id = new Guid("5ab71203-e9c7-42f3-905f-63c780c12611"),
                   Name = "Lev",
                   Surname = "Tolstoy",
                   DateOfBirth = new DateTime(1828, 9, 9),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140831"),
                   Name = "Fyodor",
                   Surname = "Dostoevsky",
                   DateOfBirth = new DateTime(1821, 11, 11),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("aa4ae982-75f4-400f-9ed3-b0d11c3523e2"),
                   Name = "Anton",
                   Surname = "Chekhov",
                   DateOfBirth = new DateTime(1860, 1, 29),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("2fafcf8b-75a9-4c61-b3ed-be974319b076"),
                   Name = "Alexander",
                   Surname = "Pushkin",
                   DateOfBirth = new DateTime(1799, 6, 6),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("24a6d8d9-df41-4380-b109-d83f60aac625"),
                   Name = "Mikhail",
                   Surname = "Bulgakov",
                   DateOfBirth = new DateTime(1891, 5, 15),
                   Country = "Russia"
               }
            );
        }
    }
}

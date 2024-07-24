using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);

            builder.HasIndex(book => book.Id)
                   .IsUnique();

            builder.Property(book => book.ISBN)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(book => book.Name)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(book => book.Genre)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(book => book.Description)
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(book => book.IsBookInLibrary)
                   .HasDefaultValue(true);

            builder.Property(book => book.TimeOfTake)
                   .HasDefaultValue(null);

            builder.Property(book => book.TimeOfReturn)
                   .HasDefaultValue(null);


            builder.HasOne(book => book.Author)
                   .WithMany(author => author.Books)
                   .HasForeignKey(book => book.AuthorId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(book => book.LibraryUser)
                   .WithMany(user => user.TakenBooks)
                   .HasForeignKey(book => book.LibraryUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Book
                {
                    Id = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c2"),
                    Name = "War and Peace",
                    AuthorId = new Guid("5ab71203-e9c7-42f3-905f-63c780c12611"),
                    ISBN = "9781566190275",
                    Genre = "Novel",
                    Description = "A novel that intertwines the lives of private and public" +
                    " individuals during the time of the Napoleonic wars.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c11"),
                    LibraryUserId = new Guid("4ec7a303-11f5-46d0-a1e4-8987b9aba75b"),
                    IsBookInLibrary = false
                },
                new Book
                {
                    Id = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2d"),
                    Name = "Anna Karenina",
                    AuthorId = new Guid("5ab71203-e9c7-42f3-905f-63c780c12611"),
                    ISBN = "9780143035008",
                    Genre = "Novel",
                    Description = "A complex novel in eight parts, with more than a dozen " +
                    "major characters, it deals with themes of betrayal, faith, family, marriage," +
                    " Imperial Russian society, desire, and rural vs. city life.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c12"),
                    LibraryUserId = new Guid("2f155e1a-d652-4a4c-b799-4d7653cdb27e"),
                    IsBookInLibrary = false
                },
                new Book
                {
                    Id = new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140832"),
                    Name = "Crime and Punishment",
                    AuthorId = new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140831"),
                    ISBN = "9780140449136",
                    Genre = "Novel",
                    Description = "A novel about the mental anguish and moral dilemmas of " +
                    "an impoverished ex-student in Saint Petersburg who formulates a plan to kill" +
                    " an unscrupulous pawnbroker for her money.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c13")
                },
                new Book
                {
                    Id = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c3"),
                    Name = "The Brothers Karamazov",
                    AuthorId = new Guid("e9e99f1f-ba87-40ee-9093-a06dc4140831"),
                    ISBN = "9780374528379",
                    Genre = "Novel",
                    Description = "A passionate philosophical novel that enters deeply into" +
                    " the ethical debates of God, free will, and morality.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c14")
                },
                new Book
                {
                    Id = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2e"),
                    Name = "The Seagull",
                    AuthorId = new Guid("aa4ae982-75f4-400f-9ed3-b0d11c3523e2"),
                    ISBN = "9780140449266",
                    Genre = "Play",
                    Description = "A play that deals with lost opportunities and unrequited love.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c15")
                },
                new Book
                {
                    Id = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c4"),
                    Name = "Uncle Vanya",
                    AuthorId = new Guid("aa4ae982-75f4-400f-9ed3-b0d11c3523e2"),
                    ISBN = "9780199536696",
                    Genre = "Play",
                    Description = "A play that portrays the visit of an elderly professor and his young" +
                    " wife, Yelena, to the rural estate that supports their urban lifestyle.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c16")
                },
                new Book
                {
                    Id = new Guid("24a6d8d9-df41-4380-b109-d83f60aac626"),
                    Name = "Eugene Onegin",
                    AuthorId = new Guid("2fafcf8b-75a9-4c61-b3ed-be974319b076"),
                    ISBN = "9780140448030",
                    Genre = "Novel",
                    Description = "A novel in verse that is a classic of Russian literature.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c17")
                },
                new Book
                {
                    Id = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c2f"),
                    Name = "The Captain's Daughter",
                    AuthorId = new Guid("2fafcf8b-75a9-4c61-b3ed-be974319b076"),
                    ISBN = "9780199538690",
                    Genre = "Novel",
                    Description = "A historical novel that depicts the rebellion of Pugachev.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c18")
                },
                new Book
                {
                    Id = new Guid("e2a6d4fd-8c3a-4b89-9fe7-9c80d9d5e9c5"),
                    Name = "The Master and Margarita",
                    AuthorId = new Guid("24a6d8d9-df41-4380-b109-d83f60aac625"),
                    ISBN = "9780141180144",
                    Genre = "Novel",
                    Description = "A novel that combines supernatural elements with satirical dark comedy.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c19")
                },
                new Book
                {
                    Id = new Guid("1a7d9b8d-6c8f-4db0-8d7b-9d9b7c0f7c30"),
                    Name = "Heart of a Dog",
                    AuthorId = new Guid("24a6d8d9-df41-4380-b109-d83f60aac625"),
                    ISBN = "9780140455151",
                    Genre = "Novel",
                    Description = "A novel about a scathing satire on Soviet Russia.",
                    ImageId = new Guid("60d8c1b4-eb78-4ab6-b283-30fd4f267c20")
                }
            );
        }
    }
}

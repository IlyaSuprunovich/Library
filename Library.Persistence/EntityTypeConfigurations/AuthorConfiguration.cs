using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            


            //Set initial data
            builder.HasData(
               new Author
               {
                   Id = new Guid("4dc4b580-7fb5-4c2a-938a-7e464116c7dd"),
                   Name = "Lev",
                   Surname = "Tolstoy",
                   DateOfBirth = new DateTime(1828, 9, 9),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("21cb29da-047a-4d85-a581-8ef6cffec67f"),
                   Name = "Maxim",
                   Surname = "Gorkiy",
                   DateOfBirth = new DateTime(1868, 3, 28),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("3bc8f089-2d00-4346-af71-d9f9fcdceb20"),
                   Name = "Miya",
                   Surname = "Kazuki",
                   DateOfBirth = new DateTime(1995, 7, 3),
                   Country = "Japan"
               },
               new Author
               {
                   Id = new Guid("188ec0f1-b4a1-4a86-9bb4-f249c2a1032b"),
                   Name = "Fedor",
                   Surname = "Dostoyevskiy",
                   DateOfBirth = new DateTime(1821, 11, 11),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("ec891ac2-f620-415f-9f86-3d15259eb071"),
                   Name = "Nikolay",
                   Surname = "Gogol",
                   DateOfBirth = new DateTime(1809, 1, 4),
                   Country = "Russia"
               },
               new Author
               {
                   Id = new Guid("4792ce31-a3e8-4df3-b0d7-4ea1c8e40dbd"),
                   Name = "William",
                   Surname = "Shakespeare",
                   DateOfBirth = new DateTime(1564, 4, 23),
                   Country = "United Kingdom"
               },
               new Author
               {
                   Id = new Guid("ac31fda2-411c-4669-8e42-b4b18cc659cb"),
                   Name = "Vasil",
                   Surname = "Bykov",
                   DateOfBirth = new DateTime(1924, 6, 22),
                   Country = "Belarus"
               }
            );
        }
    }
}

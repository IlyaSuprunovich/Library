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

            builder.Property(book => book.NumberReaderTicket)
                   .HasDefaultValue(null);

            builder.Property(book => book.TimeOfTake)
                   .HasDefaultValue(null);

            builder.Property(book => book.TimeOfReturn)
                   .HasDefaultValue(null);


            builder.HasOne(book => book.Author)
                   .WithMany(author => author.Books)
                   .HasForeignKey(book => book.AuthorId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(book => book.Image)
                   .WithOne(image => image.Book)
                   .HasForeignKey<Book>(book => book.ImageId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            

            //Set initial data
            builder.HasData(
               new Book
               {
                   Id = new Guid("14ca202e-dfb4-4d97-b7ef-76cf510bf319"),
                   Name = "War and Peace",
                   //Author = "Lev Tolstoy",
                   AuthorId = new Guid("4dc4b580-7fb5-4c2a-938a-7e464116c7dd"),
                   ISBN = "9781566190275",
                   Genre = "Novel",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("2f346383-bd6a-4564-8dce-343c355e795a"),
                   Name = "Anna Karenina",
                   //AuthorName = "Lev Tolstoy",
                   AuthorId = new Guid("4dc4b580-7fb5-4c2a-938a-7e464116c7dd"),
                   ISBN = "9780672523830",
                   Genre = "Novel",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("ad9c4dbe-5dff-43e0-a58c-cea9327a4464"),
                   Name = "Old Izergil",
                   //AuthorName = "Maxim Gorkiy",
                   AuthorId = new Guid("21cb29da-047a-4d85-a581-8ef6cffec67f"),
                   ISBN = "9798390533352",
                   Genre = "Friction",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("f31001c4-fb5d-42f0-aafd-dd0e6e08476e"),
                   Name = "Ascendance of a bookworm",
                   ///AuthorName = "Miya Kazuki",
                   AuthorId = new Guid("3bc8f089-2d00-4346-af71-d9f9fcdceb20"),
                   ISBN = "9781718357976",
                   Genre = "Friction",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("6328fcf9-5846-4f7c-960c-da5ea5c32f22"),
                   Name = "Crime and Punishment",
                   //AuthorName = "Fedor Dostoyevskiy",
                   AuthorId = new Guid("188ec0f1-b4a1-4a86-9bb4-f249c2a1032b"),
                   ISBN = "9785050000149",
                   Genre = "Novel",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("424e64e8-c811-42ef-8153-f7952ced8c51"),
                   Name = "The Brothers Karamazov",
                   //AuthorName = "Fedor Dostoyevskiy",
                   AuthorId = new Guid("188ec0f1-b4a1-4a86-9bb4-f249c2a1032b"),
                   ISBN = "0374528373",
                   Genre = "Novel",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("81ebde25-7b81-4bf2-8691-edef624642d8"),
                   Name = "Dead souls",
                   //AuthorName = "Nikolay Gogol",
                   AuthorId = new Guid("ec891ac2-f620-415f-9f86-3d15259eb071"),
                   ISBN = "0300060998",
                   Genre = "Satire",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("8e32b21e-1a32-4272-bc46-6f7b709a7696"),
                   Name = "Romeo and Juliet",
                   //AuthorName = "William Shakespeare",
                   AuthorId = new Guid("4792ce31-a3e8-4df3-b0d7-4ea1c8e40dbd"),
                   ISBN = "9780671722852",
                   Genre = "Shakespearean tragedy",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               },
               new Book
               {
                   Id = new Guid("a0283873-60b8-45de-a411-02a0a3fbc465"),
                   Name = "Alpine Ballad",
                   //AuthorName = "Vasil Bykov",
                   AuthorId = new Guid("ac31fda2-411c-4669-8e42-b4b18cc659cb"),
                   ISBN = "9781909156821",
                   Genre = "War novel",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc varius rhoncus nisl, nec egestas lacus pellentesque vitae. Donec eleifend urna at nunc tincidunt facilisis. Nam consectetur odio erat sed."
               }
            );
        }
    }
}

using Library.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class LibraryUserConfiguration : IEntityTypeConfiguration<LibraryUser>
    {
        public void Configure(EntityTypeBuilder<LibraryUser> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Id)
                   .IsUnique();

            builder.HasMany(user => user.TakenBooks)
                   .WithOne(book => book.LibraryUser)
                   .HasForeignKey(book => book.LibraryUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
               new LibraryUser
               {
                   //ilyas
                   Id = new Guid("4ec7a303-11f5-46d0-a1e4-8987b9aba75b")
               },
               new LibraryUser
               {
                   //user
                   Id = new Guid("2f155e1a-d652-4a4c-b799-4d7653cdb27e")
               }
            );
        }
    }
}

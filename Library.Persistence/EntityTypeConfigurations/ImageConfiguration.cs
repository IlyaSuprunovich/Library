using Library.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(image => image.Id);

            builder.HasIndex(image => image.Id)
                   .IsUnique();

            builder.Property(image => image.FileName)
                .IsRequired();

            builder.Property(image => image.Data)
                .IsRequired();

            builder.Property(image => image.ContentType)
                .IsRequired();

            builder.HasOne(image => image.Book)
                   .WithOne(book => book.Image)
                   .HasForeignKey<Image>(image => image.BookId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

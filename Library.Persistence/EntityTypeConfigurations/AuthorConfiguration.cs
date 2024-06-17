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
                   .HasForeignKey(book => book.AuthorId);
        }
    }
}

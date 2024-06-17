﻿using Library.Domain;
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
        }
    }
}
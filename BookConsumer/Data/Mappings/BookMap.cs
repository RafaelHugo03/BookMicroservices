using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookConsumer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookConsumer.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasColumnName("name").HasMaxLength(100).HasColumnType("varchar");
            builder.Property(b => b.AuthorName).IsRequired().HasColumnName("author_name").HasMaxLength(100).HasColumnType("varchar");
        }
    }
}
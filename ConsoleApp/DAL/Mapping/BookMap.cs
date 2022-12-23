using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAL.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.BookId);
            builder.Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(book => book.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            builder.HasOne(b=>b.Category)
                .WithMany(c=>c.Books)
                .HasForeignKey(b=>b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

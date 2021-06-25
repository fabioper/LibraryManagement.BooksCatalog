using BooksCatalog.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksCatalog.Infra.Data.Configurations
{
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books").HasKey(b => b.Id);

            builder.HasIndex(b => b.Id);

            builder.Property(b => b.Title);
            builder.Property(b => b.Author);
            builder.Property(b => b.Description);
            builder.Property(b => b.IsAvailable);
        }
    }
}
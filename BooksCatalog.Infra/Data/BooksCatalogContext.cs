using System.Reflection;
using BooksCatalog.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data
{
    public class BooksCatalogContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
        public BooksCatalogContext(DbContextOptions<BooksCatalogContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
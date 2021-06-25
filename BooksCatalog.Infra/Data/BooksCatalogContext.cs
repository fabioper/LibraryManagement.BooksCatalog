using System.Reflection;
using BooksCatalog.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace BooksCatalog.Infra.Data
{
    public sealed class BooksCatalogContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
        public BooksCatalogContext(DbContextOptions<BooksCatalogContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=BooksCatalog.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
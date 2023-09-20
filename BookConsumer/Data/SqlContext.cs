using BookConsumer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookConsumer.Data
{
    public class SqlContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public SqlContext(DbContextOptions options) : base(options)
        {
        }
    }
}
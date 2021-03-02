using Microsoft.EntityFrameworkCore;
using SearchHistoryAPI.Models;

namespace SearchHistoryAPI.Context
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SearchStatement>()
                .HasKey(st => st.Id);
        }

        public DbSet<SearchStatement> SearchStatements;
    }
}
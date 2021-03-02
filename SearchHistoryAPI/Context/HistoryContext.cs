using System;
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

            builder.Entity<SearchStatement>()
                .Property(st => st.SearchedOn);
        }

        public DbSet<SearchStatement> SearchStatements { get; set; }
    }
}
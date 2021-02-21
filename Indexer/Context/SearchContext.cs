using Microsoft.EntityFrameworkCore;
using Indexer.Models;
using Microsoft.Data.Sqlite;

namespace Indexer.Context
{
    public class SearchContext : DbContext
    {
        public SearchContext(DbContextOptions options)
            : base(options)
        {
        }

        public SearchContext()
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var sqlite = new SqliteConnection("Data Source = ../SearchEngineAPI/Search.db");
            sqlite.Open();
            builder.UseSqlite(sqlite);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Occurence>()
                .HasKey(oc => new { oc.DocumentId, oc.TermId });
            
            modelBuilder.Entity<Occurence>()
                .HasOne(oc => oc.Document)
                .WithMany(d => d.TermOccurences)
                .HasForeignKey(oc => oc.DocumentId);

            modelBuilder.Entity<Occurence>()
                .HasOne(oc => oc.Term)
                .WithMany(t => t.DocumentOccurences)
                .HasForeignKey(oc => oc.TermId);
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Occurence> Occurences { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using SearchEngineAPI.Models;

namespace SearchEngineAPI.Context
{
    public class SearchContext : DbContext
    {
        public SearchContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Occurence> Occurences { get; set; }
    }
}
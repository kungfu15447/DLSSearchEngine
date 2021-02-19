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

        DbSet<Document> Documents { get; set; }
        DbSet<Term> Terms { get; set; }
        DbSet<Occurence> Occurences { get; set; }
    }
}
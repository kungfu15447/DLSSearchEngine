using DidYouMeanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DidYouMeanAPI.Context
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
        
        public DbSet<Term> Terms { get; set; }
    }
}
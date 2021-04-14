using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DidYouMeanAPI.Context;
using DidYouMeanAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DidYouMeanAPI.Services.Implementations
{
    public class DataSource : IDataSource
    {
        private SearchContext _ctx;
        public DataSource(SearchContext ctx) 
        {
            _ctx = ctx;
        }

        public Task<bool> ExistsAsync(string s)
        {
            return _ctx.Terms.AnyAsync(t => t.Value == s);
        }

        public async Task<IEnumerable<string>> GetAllAsync()
        {
            IEnumerable<string> list = await _ctx.Terms.Select(t => t.Value).ToListAsync();
            return list;
        }
    }
}
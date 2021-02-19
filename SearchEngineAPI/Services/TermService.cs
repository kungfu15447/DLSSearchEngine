using System.Linq;
using SearchEngineAPI.Context;
using SearchEngineAPI.Models;

namespace SearchEngineAPI.Services
{
    public class TermService : ITermService
    {
        private SearchContext _ctx;
        public TermService(SearchContext ctx)
        {
            _ctx = ctx;
        }

        public Term GetTermByValue(string value)
        {
            return _ctx.Terms.FirstOrDefault(t => t.Value == value);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SearchHistoryAPI.Context;
using SearchHistoryAPI.Models;

namespace SearchHistoryAPI.Services
{
    public class HistoryService : IHistoryService
    {
        private HistoryContext _ctx;
        
        public HistoryService(HistoryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddOrUpdateStatementAsync(SearchStatement st)
        {
            var exists = _ctx.SearchStatements.Any(s => s.Id == st.Id);

            if (exists) 
            {
                st.SearchedOn = DateTime.Now;
                _ctx.SearchStatements.Update(st);
            } else 
            {
                _ctx.SearchStatements.Add(st);
            }

            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteStatementAsync(SearchStatement st)
        {
            _ctx.SearchStatements.Remove(st);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<SearchStatement>> GetHistoryAsync()
        {
            return await _ctx.SearchStatements.OrderByDescending(st => st.SearchedOn).ToListAsync();
        }

        public async Task<SearchStatement> GetStatementByIdAsync(int stId)
        {
            return await _ctx.SearchStatements.FirstOrDefaultAsync(st => st.Id == stId);
        }
    }
}
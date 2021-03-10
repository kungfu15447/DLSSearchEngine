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

        public async Task<SearchStatement> AddOrUpdateStatementAsync(string statement)
        {
            var searchStatement = await _ctx.SearchStatements.FirstOrDefaultAsync(s => s.Statement == statement);

            if (searchStatement != null)
            {
                searchStatement.SearchedOn = DateTime.Now;
            }
            else
            {
                searchStatement = new SearchStatement
                {
                    Statement = statement,
                    SearchedOn = DateTime.Now
                };
                await _ctx.SearchStatements.AddAsync(searchStatement);
            }

            await _ctx.SaveChangesAsync();
            return searchStatement;
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
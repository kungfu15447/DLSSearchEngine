using System.Collections.Generic;
using System.Threading.Tasks;
using SearchHistoryAPI.Models;

namespace SearchHistoryAPI.Services
{
    public interface IHistoryService
    {
        Task<List<SearchStatement>> GetHistoryAsync();
        Task<SearchStatement> AddOrUpdateStatementAsync(string statement);
        Task DeleteStatementAsync(SearchStatement st);
        Task<SearchStatement> GetStatementByIdAsync(int stId);
    }
}
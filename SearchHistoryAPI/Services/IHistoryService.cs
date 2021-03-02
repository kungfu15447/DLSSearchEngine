using System.Collections.Generic;
using SearchHistoryAPI.Models;

namespace SearchHistoryAPI.Services
{
    public interface IHistoryService
    {
        List<SearchStatement> GetHistory();
    }
}
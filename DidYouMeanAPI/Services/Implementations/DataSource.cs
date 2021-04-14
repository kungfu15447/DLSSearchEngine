using System.Collections.Generic;
using System.Threading.Tasks;
using DidYouMeanAPI.Services.Interfaces;

namespace DidYouMeanAPI.Services.Implementations
{
    public class DataSource : IDataSource
    {
        public DataSource() {}

        public Task<bool> ExistsAsync(string s)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
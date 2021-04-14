using System.Collections.Generic;
using System.Threading.Tasks;

namespace DidYouMeanAPI.Services.Interfaces
{
    public interface ISpellCheckerService
    {

        Task<IEnumerable<string>> GetSimilarWordsAsync(string s, double maxDistance, int maxAmount = 0);
        
        Task<IEnumerable<string>> GetSimilarWordsForceAsync(string s, double maxDistance, int maxAmount = 0);

        double Distance(string a, string b);
    }
}
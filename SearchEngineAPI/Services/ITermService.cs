using SearchEngineAPI.Models;

namespace SearchEngineAPI.Services
{
    public interface ITermService
    {
        Term GetTermByValue(string value);
    }
}
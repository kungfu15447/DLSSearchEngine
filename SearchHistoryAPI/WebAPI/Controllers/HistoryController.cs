using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchHistoryAPI.Services;
using SearchHistoryAPI.WebAPI.Models;

namespace SearchHistoryAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        private readonly ILogger _logger;

        public HistoryController(IHistoryService historyService, ILogger<HistoryController> logger)
        {
            _historyService = historyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogWarning($"Start: {_historyService.GetHashCode()} | {DateTime.UtcNow.ToString("HH:mm:ss.fff")}");
            var historyList = await _historyService.GetHistoryAsync();
            _logger.LogWarning($"End: {_historyService.GetHashCode()} | {DateTime.UtcNow.ToString("HH:mm:ss.fff")}");
            return Ok(historyList);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddStatementModel asm)
        {
            _logger.LogWarning($"Start: {_historyService.GetHashCode()} | {DateTime.UtcNow.ToString("HH:mm:ss.fff")}");
            var st = await _historyService.AddOrUpdateStatementAsync(asm.Statement.ToLower());
            _logger.LogWarning($"End: {_historyService.GetHashCode()} | {DateTime.UtcNow.ToString("HH:mm:ss.fff")}");
            return Ok(st);
        }

        [HttpDelete("{statementId}")]
        public async Task<IActionResult> Delete(int statementId)
        {
            var statement = await _historyService.GetStatementByIdAsync(statementId);

            if (statement == null) return NotFound();

            await _historyService.DeleteStatementAsync(statement);
            return Ok();
        }
    }
}
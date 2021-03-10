using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HistoryLoadBalancer.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HistoryLoadBalancer.WebApi.Controllers
{
    [ApiController]
    [Route("load/[controller]")]
    public class HistoryController : ControllerBase
    {
        private List<int> ports = new List<int>()
        {
            5002,
            5004,
            5006
        };
        private static int currentPort = 0;

        private static object myLock = new object();
        private HttpClient client;

        public HistoryController()
        {
            lock(myLock) {
                if (currentPort == ports.Count - 1)
                {
                    currentPort = 0;
                }else
                {
                    currentPort++;
                }
            }
            client = new HttpClient();
            client.BaseAddress = new Uri($"https://localhost:{ports[currentPort]}/");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await client.GetAsync("history");
            if (response.IsSuccessStatusCode)
            {
                var statements = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<SearchStatement>>(statements);
                return Ok(list);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddStatementModel asm)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(asm), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("history", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var statement = JsonConvert.DeserializeObject<SearchStatement>(content);
                return Ok(statement);
            } else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{statementId}")]
        public async Task<IActionResult> Delete(int statementId)
        {
            
            return Ok();
        }
    }
}
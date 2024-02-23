using Microsoft.AspNetCore.Mvc;
using TestTask.Data;
using Newtonsoft.Json;
using TestTask.Models;
using System.Runtime;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers
{
    [Route("/api/[controller]")]
    public class AccessPointController : Controller
    {
        private HttpClient _httpClient;        
        private IIpAddressService _service;

        public AccessPointController(HttpClient httpClient, IIpAddressService service)
        {
            _httpClient = httpClient;            
            _service = service;
        }

        [HttpGet("{ip}")]
        public async Task<IActionResult> Get(string ip) 
        {
            string url = $"https://ipinfo.io/{ip}/geo";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                var jsonData = JsonConvert.DeserializeObject<IpAddressInfo>(jsonResponse);

                await _service.SaveRequestHistory(jsonData);
                return Ok(jsonResponse);
            }
            else
            {
                return BadRequest(new { ErrorMessage = "Invalid Ip address" });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IpAddressInfo>>> GetIPInfos()
        {
            return (await _service.GetAll()).ToList();
        }
    }
}

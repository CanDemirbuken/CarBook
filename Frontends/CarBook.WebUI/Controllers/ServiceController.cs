using CarBook.Dto.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ServiceController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Services");

            if (responseMessage.IsSuccessStatusCode)
            {
                var servicesJson = await responseMessage.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(servicesJson);

                return View(services);
            }

            return View();
        }
    }
}

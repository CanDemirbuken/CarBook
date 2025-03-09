using CarBook.Dto.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Cars/GetCarWithBrand");

            if (responseMessage.IsSuccessStatusCode)
            {
                var carssJson = await responseMessage.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDTO>>(carssJson);

                return View(cars);
            }

            return View();
        }
    }
}

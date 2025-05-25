using CarBook.Dto.CarPricingDTOs;
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
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/CarPricings");

            if (responseMessage.IsSuccessStatusCode)
            {
                var carsJson = await responseMessage.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarsDTO>>(carsJson);

                return View(cars);
            }

            return View();
        }
    }
}

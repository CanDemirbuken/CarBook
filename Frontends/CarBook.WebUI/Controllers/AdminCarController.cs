using CarBook.Dto.BrandDTOs;
using CarBook.Dto.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Cars/GetCarWithBrand");

            if (responseMessage.IsSuccessStatusCode)
            {
                var carJson = await responseMessage.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDTO>>(carJson);

                return View(cars);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Brands");

            if (responseMessage.IsSuccessStatusCode)
            {
                var brandJson = await responseMessage.Content.ReadAsStringAsync();
                var brands = JsonConvert.DeserializeObject<List<ResultBrandDTO>>(brandJson);
                
                List<SelectListItem> brandValues = (from x in brands
                                                    select new SelectListItem
                                                    {
                                                        Value = x.BrandID.ToString(),
                                                        Text = x.Name
                                                    }).ToList();

                ViewBag.brandValues = brandValues;
                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(RequestCreateCarDTO requestCreateCarDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(requestCreateCarDTO);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7128/api/Cars", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7128/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7128/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var carJson = await responseMessage.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<RequestUpdateCarDTO>(carJson);

                var brandResponse = await client.GetAsync("https://localhost:7128/api/Brands");
                if (brandResponse.IsSuccessStatusCode)
                {
                    var brandJson = await brandResponse.Content.ReadAsStringAsync();
                    var brands = JsonConvert.DeserializeObject<List<ResultBrandDTO>>(brandJson);
                    List<SelectListItem> brandValues = (from x in brands
                                                        select new SelectListItem
                                                        {
                                                            Value = x.BrandID.ToString(),
                                                            Text = x.Name,
                                                            Selected = x.BrandID == car.BrandID
                                                        }).ToList();
                    ViewBag.brandValues = brandValues;
                    return View(car);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(RequestUpdateCarDTO requestUpdateCarDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(requestUpdateCarDTO);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7128/api/Cars/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

using CarBook.Dto.BrandDTOs;
using CarBook.Dto.CarDTOs;
using CarBook.Dto.FeatureDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Features/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var featureJson = await responseMessage.Content.ReadAsStringAsync();
                var features = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(featureJson);

                return View(features);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(RequestCreateFeatureDTO requestCreateFeatureDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(requestCreateFeatureDTO);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7128/api/Features", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> RemoveFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7128/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7128/api/Features/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var featureJson = await responseMessage.Content.ReadAsStringAsync();
                var feature = JsonConvert.DeserializeObject<RequestUpdateFeatureDTO>(featureJson);

                return View(feature);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(RequestUpdateFeatureDTO requestUpdateFeatureDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(requestUpdateFeatureDTO);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7128/api/Features/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

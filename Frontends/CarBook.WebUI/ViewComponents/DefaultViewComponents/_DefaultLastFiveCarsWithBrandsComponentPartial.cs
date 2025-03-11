using CarBook.Dto.CarDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultLastFiveCarsWithBrandsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultLastFiveCarsWithBrandsComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Cars/GetLastFiveCarWithBrand");

            if (responseMessage.IsSuccessStatusCode)
            {
                var carsJson = await responseMessage.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultLastFiveCarWithBrandsDTO>>(carsJson);

                return View(cars);
            }

            return View();
        }
    }
}

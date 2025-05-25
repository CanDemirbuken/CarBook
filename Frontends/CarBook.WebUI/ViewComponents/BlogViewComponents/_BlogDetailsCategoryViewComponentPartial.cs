using CarBook.Dto.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsCategoryViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7128/api/Categories/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var categoryJson = await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(categoryJson);

                return View(categories);
            }

            return View();
        }
    }
}

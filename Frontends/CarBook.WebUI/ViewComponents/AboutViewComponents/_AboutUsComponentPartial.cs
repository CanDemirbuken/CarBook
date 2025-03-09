using CarBook.Dto.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responeMessage = await client.GetAsync("https://localhost:7128/api/Abouts");

            if (responeMessage.IsSuccessStatusCode)
            {
                var aboutsJson = await responeMessage.Content.ReadAsStringAsync();
                var abouts = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(aboutsJson);

                return View(abouts);
            }

            return View();
        }
    }
}

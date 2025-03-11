using CarBook.Dto.BannerDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Banners");

            if (responseMessage.IsSuccessStatusCode)
            {
                var bannersJson = await responseMessage.Content.ReadAsStringAsync();
                var banners = JsonConvert.DeserializeObject<List<ResultBannerDTO>>(bannersJson);

                return View(banners);
            }

            return View();
        }
    }
}

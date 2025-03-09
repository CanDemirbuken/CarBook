using CarBook.Dto.FooterAddressDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/FooterAddresses");

            if (responseMessage.IsSuccessStatusCode)
            {
                var footerAddressesJson = await responseMessage.Content.ReadAsStringAsync();
                var footerAddresses = JsonConvert.DeserializeObject<List<ResultFooterAddressDTO>>(footerAddressesJson);

                return View(footerAddresses);
            }

            return View();
        }
    }
}

using CarBook.Dto.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _TestimonialComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Testimonials");

            if (responseMessage.IsSuccessStatusCode)
            {
                var testimonialsJson = await responseMessage.Content.ReadAsStringAsync();
                var testimonials = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(testimonialsJson);

                return View(testimonials);
            }

            return View();
        }
    }
}

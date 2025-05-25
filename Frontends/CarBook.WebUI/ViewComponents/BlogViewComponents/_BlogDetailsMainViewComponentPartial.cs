using CarBook.Dto.BlogDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _BlogDetailsMainViewComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7128/api/Blogs/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var blogsJson = await responseMessage.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<ResultGetBlogByIdDTO>(blogsJson);

                return View(blogs);
            }

            return View();
        }
    }
}

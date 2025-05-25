using CarBook.Dto.TagCloudDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCloudTagByBlogViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public _BlogDetailsCloudTagByBlogViewComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogId = id;

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7128/api/TagClouds/GetTagCloudByBlogId?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var tagCloudJson = await responseMessage.Content.ReadAsStringAsync();
                var tagClouds = JsonConvert.DeserializeObject<List<ResultTagCloudByBlogIdDTO>>(tagCloudJson);

                return View(tagClouds);
            }

            return View();
        }
    }
}

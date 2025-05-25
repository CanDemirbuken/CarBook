using CarBook.Dto.BlogDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _BlogDetailsRecentBlogsViewComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Blogs/GetLastThreeBlogWithAuthor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var blogsJson = await responseMessage.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<ResultLastThreeBlogWithAuthorDTO>>(blogsJson);

                return View(blogs);
            }

            return View();
        }
    }
}

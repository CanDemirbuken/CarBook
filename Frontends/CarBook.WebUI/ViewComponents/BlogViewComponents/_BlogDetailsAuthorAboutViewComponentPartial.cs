using CarBook.Dto.AuthorDTOs;
using CarBook.Dto.TagCloudDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public _BlogDetailsAuthorAboutViewComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogId = id;

            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7128/api/Blogs/GetBlogByAuthorId?blogId=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var blogWithAuthorJson = await responseMessage.Content.ReadAsStringAsync();
                var blogWithAuthor = JsonConvert.DeserializeObject<List<ResultAuthorByBlogAuthorIdDTO>>(blogWithAuthorJson);

                return View(blogWithAuthor);
            }

            return View();
        }
    }
}

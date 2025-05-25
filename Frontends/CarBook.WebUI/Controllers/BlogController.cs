using CarBook.Dto.BlogDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BlogController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglarımız";
            ViewBag.v2 = "Yazarlarımızın Blogları";

            var client =  _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Blogs/GetBlogsWithAuthor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var blogJson = await responseMessage.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<List<ResultBlogWithAuthorDTO>>(blogJson);

                return View(blogs);
            }

            return View();
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Blog Detayı";
            ViewBag.blogId = id;

            return View();
        }
    }
}

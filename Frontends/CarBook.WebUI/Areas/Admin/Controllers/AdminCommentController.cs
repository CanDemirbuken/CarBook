using CarBook.Dto.CommentDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Comments/CommentListByBlog?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var commentJson = await responseMessage.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<ResultCommentDTO>>(commentJson);

                return View(comments);
            }

            return View();
        }
    }
}

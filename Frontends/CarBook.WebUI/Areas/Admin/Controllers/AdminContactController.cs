using CarBook.Dto.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContact")]
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7128/api/Contacts/");

            if (responseMessage.IsSuccessStatusCode)
            {
                var contactJson = await responseMessage.Content.ReadAsStringAsync();
                var contacts = JsonConvert.DeserializeObject<List<ResultContactDTO>>(contactJson);

                return View(contacts);
            }

            return View();
        }
    }
}

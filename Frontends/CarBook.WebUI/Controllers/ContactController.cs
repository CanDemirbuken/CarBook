using CarBook.Dto.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RequestCreateContactDTO request)
        {
            request.SendDate = DateTime.Now;

            var client = _clientFactory.CreateClient();
            var contactJson = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(contactJson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7128/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Default");

            else
                return View();
        }
    }
}

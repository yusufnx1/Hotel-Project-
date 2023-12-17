using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContact)
        {
            createContact.Date = DateTime.Parse(DateTime.Now.ToString());
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createContact);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PostAsync("http://localhost:5069/api/Contact", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Defalt");
            }
            return View();
        }
    }
}

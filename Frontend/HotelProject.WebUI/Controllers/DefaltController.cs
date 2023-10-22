using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class DefaltController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaltController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribe)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createSubscribe);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PostAsync("http://localhost:5069/api/Subscribe", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Defalt");
            }
            return View();
        }
    }
}

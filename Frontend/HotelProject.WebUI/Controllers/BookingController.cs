using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult BookingAdd()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> BookingAdd(CreateBookingDto createBooking)
        {
            createBooking.Description = string.Empty;
            createBooking.Status = "Onay Bekliyor";
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createBooking);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PostAsync("http://localhost:5069/api/Booking", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Defalt");
            }
            return View();
        }
    }
}
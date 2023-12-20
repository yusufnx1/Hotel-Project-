using HotelProject.WebUI.Dtos.AppUser;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AppUserWorkLocationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppUserWorkLocationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]

        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("http://localhost:5069/api/AppUserWorkLocation");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserWhitWorkLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

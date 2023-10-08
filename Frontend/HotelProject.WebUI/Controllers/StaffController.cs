using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("http://localhost:5069/api/Staff");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PostAsync("http://localhost:5069/api/Staff", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.DeleteAsync($"http://localhost:5069/api/Staff/{id}");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync($"http://localhost:5069/api/Staff/{id}");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateViewModel update)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(update);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responsiveMessage = await client.PutAsync("http://localhost:5069/api/Staff/", stringContent);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

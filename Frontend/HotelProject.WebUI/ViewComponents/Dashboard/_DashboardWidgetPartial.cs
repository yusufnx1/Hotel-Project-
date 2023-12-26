using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("http://localhost:5069/api/DashboardWidget/StaffCount");
            var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
            ViewBag.staffCount = jsonData;

            var client1 = _httpClientFactory.CreateClient();
            var responsiveMessage1 = await client1.GetAsync("http://localhost:5069/api/DashboardWidget/BookingCount");
            var jsonData1 = await responsiveMessage1.Content.ReadAsStringAsync();
            ViewBag.bookingCount = jsonData1;

            var client2 = _httpClientFactory.CreateClient();
            var responsiveMessage2 = await client2.GetAsync("http://localhost:5069/api/DashboardWidget/AppUserCount");
            var jsonData2 = await responsiveMessage2.Content.ReadAsStringAsync();
            ViewBag.appUserCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var responsiveMessage3 = await client3.GetAsync("http://localhost:5069/api/DashboardWidget/RoomCount");
            var jsonData3 = await responsiveMessage3.Content.ReadAsStringAsync();
            ViewBag.roomCount = jsonData3;

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast4StaffPartial:ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _DashboardLast4StaffPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("http://localhost:5069/api/DashboardWidget/Last4Staff");
            var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
            ViewBag.staffCount = jsonData;
            return View();
        }
    }
}

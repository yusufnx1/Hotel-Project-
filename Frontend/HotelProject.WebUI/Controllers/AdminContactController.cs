﻿using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("http://localhost:5069/api/Contact");

            var client1 = _httpClientFactory.CreateClient();
            var responsiveMessage2 = await client1.GetAsync("http://localhost:5069/api/Contact/GetContactCount");

            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var jsonData2= await responsiveMessage2.Content.ReadAsStringAsync();
                ViewBag.contantCount = jsonData2;
                return View(values);
            }
            return View();
        }
        public async Task<PartialViewResult> SidebarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateSendMessage createSendMessage)
        {
            createSendMessage.SenderMail = "admin@gmail.com";
            createSendMessage.SenderName = "admin";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsiveMessage = await client.PostAsync("http://localhost:5069/api/SendMessage", content);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync("http://localhost:5069/api/SendMessage");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsBySenbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync($"http://localhost:5069/api/SendMessage/{id}");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsiveMessage = await client.GetAsync($"http://localhost:5069/api/Contact/{id}");
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}

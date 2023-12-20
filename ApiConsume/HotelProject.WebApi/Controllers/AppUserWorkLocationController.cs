using HotelProject.BusinnesLayer.Abstrack;
using HotelProject.DataAccesLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserWorkLocationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
           // var values = _appUserService.TUserListWhitWorkLocations();
           Context context  = new Context();
            var values = context.Users.Include(x => x.WorkLocation).Select(y=> new AppUserWorklocationViewModel
            {
                Name = y.Name,
                Surname = y.Surname,
                WorkLocationId = y.WorkLocationId,
                WorkLocationName = y.WorkLocation.WorkLocationCityName,
                Gender= y.Gender,
                Country = y.Country,
                City= y.City
            }).ToList();
            return Ok(values);
        }
    }
}

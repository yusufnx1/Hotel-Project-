using HotelProject.BusinnesLayer.Abstrack;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;
        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var values = _staffService.GetStaffCount();
            return Ok(values);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var values = _bookingService.GetBookingCount();
            return Ok(values);
        }
        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var values = _appUserService.TAppUserCout();
            return Ok(values);
        }
        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var values = _roomService.TRoomCount();
            return Ok(values);
        }
        [HttpGet("Last4Staff")]
        public IActionResult Last4Staff()
        {
            var values = _staffService.Last4Staff();
            return Ok(values);
        }
    }
}

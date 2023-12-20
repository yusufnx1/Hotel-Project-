using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinnesLayer.Abstrack
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        List<AppUser> TUserListWhitWorkLocation();
        List<AppUser> TUserListWhitWorkLocations();
    }
}
